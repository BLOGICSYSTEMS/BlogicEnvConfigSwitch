using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;

public static class AdminHelper
{
    public static void EnsureRunAsAdmin()
    {
        if (!IsRunAsAdmin())
        {
            MessageBox.Show("The application needs Administrator to run.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static bool IsRunAsAdmin()
    {
        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
        {
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
