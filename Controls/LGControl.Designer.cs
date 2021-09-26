namespace GzLauncher
{
    partial class LGControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SelectPanel = new Guna.UI.WinForms.GunaElipsePanel();
            this.CoverImage = new Guna.UI.WinForms.GunaPictureBox();
            this.lblGameName = new Guna.UI.WinForms.GunaLabel();
            this.SelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // SelectPanel
            // 
            this.SelectPanel.BackColor = System.Drawing.Color.Transparent;
            this.SelectPanel.BaseColor = System.Drawing.Color.Black;
            this.SelectPanel.Controls.Add(this.CoverImage);
            this.SelectPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectPanel.Name = "SelectPanel";
            this.SelectPanel.Size = new System.Drawing.Size(200, 275);
            this.SelectPanel.TabIndex = 0;
            // 
            // CoverImage
            // 
            this.CoverImage.BaseColor = System.Drawing.Color.White;
            this.CoverImage.Location = new System.Drawing.Point(4, 4);
            this.CoverImage.Name = "CoverImage";
            this.CoverImage.Size = new System.Drawing.Size(193, 268);
            this.CoverImage.TabIndex = 0;
            this.CoverImage.TabStop = false;
            this.CoverImage.WaitOnLoad = true;
            // 
            // lblGameName
            // 
            this.lblGameName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGameName.Location = new System.Drawing.Point(4, 278);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(184, 23);
            this.lblGameName.TabIndex = 1;
            this.lblGameName.Text = "gunaLabel1";
            this.lblGameName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DGControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.lblGameName);
            this.Controls.Add(this.SelectPanel);
            this.Name = "DGControl";
            this.Size = new System.Drawing.Size(200, 300);
            this.SelectPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CoverImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipsePanel SelectPanel;
        private Guna.UI.WinForms.GunaLabel lblGameName;
        private Guna.UI.WinForms.GunaPictureBox CoverImage;
    }
}
