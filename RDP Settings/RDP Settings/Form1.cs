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
    public partial class mainForm : Form
    {
        // Define the location, in the registry, where MRU data lives. Set to true so it's not read-only.
        RegistryKey mruLoc = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Default", true);
        RegistryKey portKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Terminal Server\\WinStations\\RDP-Tcp", true);

        private void updateReg()
        {
            // Action to update Tab 2 - RDP History
            chkBox_pwHint.Items.Clear();
            RegistryKey key2 = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Servers");
            try
            {
                foreach (string subKeyName in key2.GetSubKeyNames())
                {
                    chkBox_pwHint.Items.Add(subKeyName);
                }
            }
            catch
            {
                MessageBox.Show("There was an error opening the 'Servers' key", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }
        private void updateMRU()
        {
            // Action to update Tab 1 - Most Recently Used (MRU)
            // Create an array of text boxes, so we can go through them in code.
            TextBox[] boxes = new[]
            {
                txtBox_mru0,
                txtBox_mru1,
                txtBox_mru2,
                txtBox_mru3,
                txtBox_mru4,
                txtBox_mru5,
                txtBox_mru6,
                txtBox_mru7,
                txtBox_mru8,
                txtBox_mru9,
            };

            // Clear the boxes if there are any values.
            for(int clear = 0; clear < 10; clear++)
            {
                boxes[clear].Clear();
            }
            // Iterate through the 10 built in MRU values, and plug them into the appropriate boxes.
            for(int i = 0; i < 10; i++)
            {
                string currentMRU = "MRU" + i;
                string mruValue = "";
                try
                {
                    mruValue = mruLoc.GetValue(currentMRU).ToString();
                }
                catch
                {
                    mruValue = "";
                }
                boxes[i].Text = mruValue;
            }
        }

        public mainForm()
        {
            InitializeComponent();
            updateReg();
            updateMRU();
            txtBox_3_port.Text = portKey.GetValue("PortNumber").ToString();
            MessageBox.Show(@"This program makes changes to the Windows Registry.
Make sure you have a backup!","Warning!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btn_1_refresh_Click(object sender, EventArgs e)
        {
            // Update MRU button
            updateMRU();
        }

        private void btn_1_update_Click(object sender, EventArgs e)
        {
            // Write new data
            TextBox[] boxes = new[]
            {
                txtBox_mru0,
                txtBox_mru1,
                txtBox_mru2,
                txtBox_mru3,
                txtBox_mru4,
                txtBox_mru5,
                txtBox_mru6,
                txtBox_mru7,
                txtBox_mru8,
                txtBox_mru9,
            };
            for (int i = 0; i < 10; i++)
            {
                string currentMRU = "MRU" + i;
                mruLoc.SetValue(currentMRU,boxes[i].Text);
            }
            MessageBox.Show("New values written!", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_2_editEntry_Click(object sender, EventArgs e)
        {
            // Edit button on Tab 2 pressed
            foreach (string itemChecked in chkBox_pwHint.CheckedItems)
            {
                RegistryKey subKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Servers\\" + itemChecked);
                // This next line is causing a crash when you change the main key name, but the list doesn't refresh.
                // Design decision: I have disabled the main key box from being edit-able, since that is not the purpose 
                //   of this function.
                string usernameHintValue = subKey.GetValue("UsernameHint").ToString();
                Form m = new editRDPSettings(itemChecked, usernameHintValue);
                m.ShowDialog();
            }
            updateReg();
        }

        private void btn_2_delEntries_Click(object sender, EventArgs e)
        {
            // Delete button pressed (Tab 2)
            RegistryKey oldKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Terminal Server Client\\Servers", true);
            foreach (string itemChecked in chkBox_pwHint.CheckedItems)
            {
                oldKey.DeleteSubKey(itemChecked);
            }
            updateReg();
        }

        private void btn_3_update_Click(object sender, EventArgs e)
        {
            // Update RDP Port Button Pressed
            portKey.SetValue("PortNumber", txtBox_3_port.Text, RegistryValueKind.DWord);
            MessageBox.Show("RDP Port has been changed.\nPlease restart your machine for settings to take effect.", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_About_Click_1(object sender, EventArgs e)
        {
            Form aboutFormView = new aboutForm();
            aboutFormView.ShowDialog();
        }

        private void btn_2_Refresh_Click(object sender, EventArgs e)
        {

        }


    }
}
