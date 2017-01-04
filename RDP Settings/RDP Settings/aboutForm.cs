using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RDP_Settings
{
    public partial class aboutForm : Form
    {
        public aboutForm()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            lbl_Version.Text = "Version: " + Application.ProductVersion;
        }

        private void btn_Website_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.georgebabichev.com");
        }
    }
}
