namespace RDP_Settings
{
    partial class editRDPSettings
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
            this.rdpKeyBox = new System.Windows.Forms.TextBox();
            this.btn_Save = new System.Windows.Forms.Button();
            this.usernameHintBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rdpKeyBox
            // 
            this.rdpKeyBox.Location = new System.Drawing.Point(14, 12);
            this.rdpKeyBox.Name = "rdpKeyBox";
            this.rdpKeyBox.Size = new System.Drawing.Size(224, 20);
            this.rdpKeyBox.TabIndex = 1;
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(162, 66);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(75, 23);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // usernameHintBox
            // 
            this.usernameHintBox.Location = new System.Drawing.Point(13, 40);
            this.usernameHintBox.Name = "usernameHintBox";
            this.usernameHintBox.Size = new System.Drawing.Size(224, 20);
            this.usernameHintBox.TabIndex = 2;
            // 
            // editRDPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 94);
            this.Controls.Add(this.usernameHintBox);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.rdpKeyBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "editRDPSettings";
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox rdpKeyBox;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.TextBox usernameHintBox;
    }
}