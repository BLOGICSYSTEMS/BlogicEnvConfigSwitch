using System.Windows.Forms;

namespace BlogicEnvConfigSwitch
{
    partial class BlogicEnvConfigSwitchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkStaging = new System.Windows.Forms.CheckBox();
            this.chkPreProduction = new System.Windows.Forms.CheckBox();
            this.chkProduction = new System.Windows.Forms.CheckBox();
            this.radPOS = new System.Windows.Forms.RadioButton();
            this.radWeb = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 64);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::BlogicEnvConfigSwitch.Properties.Resources.icon_close;
            this.btnClose.Location = new System.Drawing.Point(20, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 130;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(329, 44);
            this.label4.TabIndex = 129;
            this.label4.Text = "Enviroment Config Switch";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(148)))), ((int)(((byte)(68)))));
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Font = new System.Drawing.Font("Roboto", 12F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(0, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(401, 48);
            this.btnSave.TabIndex = 752;
            this.btnSave.Text = "Change";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // chkStaging
            // 
            this.chkStaging.AutoSize = true;
            this.chkStaging.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.chkStaging.Location = new System.Drawing.Point(58, 119);
            this.chkStaging.Name = "chkStaging";
            this.chkStaging.Size = new System.Drawing.Size(114, 33);
            this.chkStaging.TabIndex = 753;
            this.chkStaging.Text = "Staging";
            this.chkStaging.UseVisualStyleBackColor = true;
            // 
            // chkPreProduction
            // 
            this.chkPreProduction.AutoSize = true;
            this.chkPreProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.chkPreProduction.Location = new System.Drawing.Point(58, 176);
            this.chkPreProduction.Name = "chkPreProduction";
            this.chkPreProduction.Size = new System.Drawing.Size(194, 33);
            this.chkPreProduction.TabIndex = 753;
            this.chkPreProduction.Text = "Pre-Production";
            this.chkPreProduction.UseVisualStyleBackColor = true;
            // 
            // chkProduction
            // 
            this.chkProduction.AutoSize = true;
            this.chkProduction.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.chkProduction.Location = new System.Drawing.Point(58, 238);
            this.chkProduction.Name = "chkProduction";
            this.chkProduction.Size = new System.Drawing.Size(148, 33);
            this.chkProduction.TabIndex = 753;
            this.chkProduction.Text = "Production";
            this.chkProduction.UseVisualStyleBackColor = true;
            // 
            // radPOS
            // 
            this.radPOS.AutoSize = true;
            this.radPOS.Checked = true;
            this.radPOS.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.radPOS.Location = new System.Drawing.Point(89, 4);
            this.radPOS.Name = "radPOS";
            this.radPOS.Size = new System.Drawing.Size(82, 33);
            this.radPOS.TabIndex = 754;
            this.radPOS.TabStop = true;
            this.radPOS.Text = "POS";
            this.radPOS.UseVisualStyleBackColor = true;
            // 
            // radWeb
            // 
            this.radWeb.AutoSize = true;
            this.radWeb.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.radWeb.Location = new System.Drawing.Point(216, 4);
            this.radWeb.Name = "radWeb";
            this.radWeb.Size = new System.Drawing.Size(81, 33);
            this.radWeb.TabIndex = 755;
            this.radWeb.TabStop = true;
            this.radWeb.Text = "Web";
            this.radWeb.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radPOS);
            this.panel2.Controls.Add(this.radWeb);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 64);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(401, 41);
            this.panel2.TabIndex = 756;
            // 
            // BlogicEnvConfigSwitchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(401, 339);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.chkProduction);
            this.Controls.Add(this.chkPreProduction);
            this.Controls.Add(this.chkStaging);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BlogicEnvConfigSwitchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.BlogicEnvConfigSwitchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkStaging;
        private System.Windows.Forms.CheckBox chkPreProduction;
        private System.Windows.Forms.CheckBox chkProduction;
        private System.Windows.Forms.RadioButton radPOS;
        private System.Windows.Forms.RadioButton radWeb;
        private System.Windows.Forms.Panel panel2;
    }
}

