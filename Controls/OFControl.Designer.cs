namespace GzLauncher
{
    partial class OFControl
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
            this.fileIconPic = new Guna.UI.WinForms.GunaPictureBox();
            this.lblFileName = new Guna.UI.WinForms.GunaLabel();
            ((System.ComponentModel.ISupportInitialize)(this.fileIconPic)).BeginInit();
            this.SuspendLayout();
            // 
            // fileIconPic
            // 
            this.fileIconPic.BackgroundImage = global::GzLauncher.Properties.Resources.icons8_qb_480px;
            this.fileIconPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileIconPic.BaseColor = System.Drawing.Color.White;
            this.fileIconPic.Location = new System.Drawing.Point(30, 26);
            this.fileIconPic.Name = "fileIconPic";
            this.fileIconPic.Size = new System.Drawing.Size(50, 50);
            this.fileIconPic.TabIndex = 0;
            this.fileIconPic.TabStop = false;
            // 
            // lblFileName
            // 
            this.lblFileName.Font = new System.Drawing.Font("Russo One", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.White;
            this.lblFileName.Location = new System.Drawing.Point(86, 26);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(133, 50);
            this.lblFileName.TabIndex = 1;
            this.lblFileName.Text = "Detroit.Become.Human-DRMFREE";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OFControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.fileIconPic);
            this.Name = "OFControl";
            this.Size = new System.Drawing.Size(250, 100);
            ((System.ComponentModel.ISupportInitialize)(this.fileIconPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox fileIconPic;
        private Guna.UI.WinForms.GunaLabel lblFileName;
    }
}
