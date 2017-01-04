using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RDP_Settings
{
    public partial class editRDPSettings : Form
    {
        string previousRDPHost;
        string previousUserNameHint;

        public editRDPSettings(string rdpHost, string UsernameHint)
        {
            InitializeComponent();
            rdpKeyBox.Text = rdpHost;
            usernameHintBox.Text = UsernameHint;
            previousRDPHost = rdpHost;
            previousUserNameHint = UsernameHint;
            rdpKeyBox.Enabled = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            // Get data that is currently in the text box
            string newRDPHost = rdpKeyBox.Text;
            string newUserNameHint = usernameHintBox.Text;
            // Delete previous value
            RegistryKey oldKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Servers",true);
            oldKey.DeleteSubKeyTree(previousRDPHost);

            // Create new value
            oldKey.CreateSubKey(newRDPHost);
            RegistryKey newKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Servers\\" + newRDPHost, true);
            newKey.SetValue("UsernameHint", newUserNameHint);
            this.Close();
        }
    }
}
