using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Newtonsoft.Json;

namespace BlogicEnvConfigSwitch
{
    public partial class BlogicEnvConfigSwitchForm : Form
    {
        #region Variables
        // Tracks whether any values have been changed
        private bool _isChangedValues = false;
        string appPoolName = "DefaultAppPool"; // Default application pool name

        #endregion

        public BlogicEnvConfigSwitchForm()
        {
            InitializeComponent();
            RegisterEvents(); // Register initial button events
            DisableBtnSave(); // Disable the Save button by default
        }

        private void BlogicEnvConfigSwitchForm_Load(object sender, EventArgs e)
        {
            // Unregister and re-register checkbox events during form load
            UnRegisterEventsForChanged();
            RegisterEventsForChanged();
        }

        private void RegisterEvents()
        {
            // Register button click and state change events
            btnClose.Click += this.BtnClose_Click;
            btnSave.Click += this.BtnSave_Click;
            btnSave.EnabledChanged += BtnSave_EnabledChanged;

        }

        public void RegisterEventsForChanged()
        {
            // Register CheckedChanged events for all checkboxes
            chkStaging.CheckedChanged += CheckChangedHandler;
            chkPreProduction.CheckedChanged += CheckChangedHandler;
            chkProduction.CheckedChanged += CheckChangedHandler;
            radPOS.CheckedChanged += ChangeEvent;
            radWeb.CheckedChanged += ChangeEvent;
        }

        public void UnRegisterEventsForChanged()
        {
            // Unregister CheckedChanged events for all checkboxes
            chkStaging.CheckedChanged -= CheckChangedHandler;
            chkPreProduction.CheckedChanged -= CheckChangedHandler;
            chkProduction.CheckedChanged -= CheckChangedHandler;
            radPOS.CheckedChanged -= ChangeEvent;
            radWeb.CheckedChanged -= ChangeEvent;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DisableBtnSave(); // Disable the Save button after saving

                // Determine the selected environment
                string env = chkStaging.Checked ? "staging" : chkPreProduction.Checked ? "preproduction" : "production";
                string siteName = "Default Web Site";

                string configPath = GetWebConfigPathFromIIS(siteName);

                string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config-settings.json");

                // Deserialize JSON to get appSettings
                var json = File.ReadAllText(jsonPath);
                var configData = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                var appSettings = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(configData["appSettings"].ToString());

                // Handle multiple config paths
                var arrConfigPath = configPath.Split(',');

                foreach (var configPathItem in arrConfigPath)
                {
                    if (File.Exists(configPathItem))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(configPathItem);

                        // Locate the <appSettings> section in the config file
                        XmlNode appSettingsNode = doc.SelectSingleNode("/configuration/appSettings");
                        if (appSettingsNode == null)
                        {
                            MessageBox.Show("Cannot find "+ configPathItem);
                            return;
                        }

                        // Update settings based on the selected environment
                        foreach (var kvp in appSettings)
                        {
                            string key = kvp.Key;
                            if (!kvp.Value.ContainsKey(env)) continue;

                            string newValue = kvp.Value[env];
                            XmlNode settingNode = appSettingsNode.SelectSingleNode($"add[@key='{key}']");

                            if (settingNode != null && settingNode.Attributes["value"] != null)
                            {
                                settingNode.Attributes["value"].Value = newValue;
                            }
                            else
                            {
                                // Add new setting if it doesn't exist
                                XmlElement newSetting = doc.CreateElement("add");
                                newSetting.SetAttribute("key", key);
                                newSetting.SetAttribute("value", newValue);
                                appSettingsNode.AppendChild(newSetting);
                            }
                        }

                        doc.Save(configPathItem); // Save the updated config file
                    }
                }

                RestartAppPool(appPoolName); // Restart the application pool

                MessageBox.Show("Updated and restart IIS.", "Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
            }
        }

        private string GetWebConfigPathFromIIS(string siteName)
        {
            string hardcodedPath = @"";

            string jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config-settings.json");

            try
            {
                var json = File.ReadAllText(jsonPath);
                var settings = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, object>>>(json);

                if (settings.ContainsKey("Paths"))
                {
                    var paths = settings["Paths"];
                    if (radPOS.Checked && paths.ContainsKey("POS") && paths["POS"] is Newtonsoft.Json.Linq.JArray posPaths)
                    {
                        hardcodedPath = string.Join(",", posPaths);
                    }
                    else if (radWeb.Checked && paths.ContainsKey("Web") && paths["Web"] is Newtonsoft.Json.Linq.JArray webPaths)
                    {
                        hardcodedPath = string.Join(",", webPaths);
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Error reading config-settings.json: {ex.Message}");
            }

            return hardcodedPath;
        }

        private void RestartAppPool(string appPoolName)
        {
            // Restart the IIS application pool using appcmd.exe
            string appcmdPath = @"C:\Windows\System32\inetsrv\appcmd.exe";

            Process.Start(appcmdPath, "stop site \"Default Web Site\"");
            Process.Start(appcmdPath, "start site \"Default Web Site\"");
        }

        private void CheckChangedProcessing(CheckBox changed)
        {
            if (!changed.Checked) return; // Only process when a checkbox is checked

            // Temporarily unregister events to avoid recursion
            chkStaging.CheckedChanged -= CheckChangedHandler;
            chkPreProduction.CheckedChanged -= CheckChangedHandler;
            chkProduction.CheckedChanged -= CheckChangedHandler;

            // Ensure only one checkbox is checked at a time
            chkStaging.Checked = changed == chkStaging;
            chkPreProduction.Checked = changed == chkPreProduction;
            chkProduction.Checked = changed == chkProduction;

            // Re-register events
            chkStaging.CheckedChanged += CheckChangedHandler;
            chkPreProduction.CheckedChanged += CheckChangedHandler;
            chkProduction.CheckedChanged += CheckChangedHandler;
        }

        private void CheckChangedHandler(object sender, EventArgs e)
        {
            // Handle checkbox state changes
            CheckChangedProcessing((CheckBox)sender);
            ChangeEvent(sender, e);
        }

        public void ChangeEvent(object sender, EventArgs e)
        {
            // Enable the Save button when a change is detected
            if ((radPOS.Checked || radWeb.Checked) && (chkStaging.Checked || chkPreProduction.Checked || chkProduction.Checked))
            {
                EnableBtnSave();
            }
        }

        private void BtnSave_EnabledChanged(object sender, EventArgs e)
        {
            // Update the appearance of the Save button based on its enabled state
            if (sender is Button button)
            {
                bool enabled = button.Enabled;
                button.BackColor = enabled ? Color.FromArgb(11, 148, 68) : Color.FromArgb(220, 220, 220);
                button.FlatAppearance.BorderColor = enabled ? Color.FromArgb(11, 108, 28) : Color.FromArgb(180, 180, 180);
                button.ForeColor = enabled ? Color.White : Color.Black;
            }
        }

        public void EnableBtnSave()
        {
            // Enable the Save button
            btnSave.Enabled = true;
        }

        public void DisableBtnSave()
        {
            // Disable the Save button
            btnSave.Enabled = false;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
