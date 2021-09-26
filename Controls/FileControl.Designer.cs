namespace GzLauncher
{
    partial class FileControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileControl));
            this.fileIconPic = new Guna.UI.WinForms.GunaPictureBox();
            this.lblFileName = new Guna.UI.WinForms.GunaLabel();
            this.btnFileDel = new Guna.UI.WinForms.GunaAdvenceButton();
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
            // btnFileDel
            // 
            this.btnFileDel.AnimationHoverSpeed = 0.07F;
            this.btnFileDel.AnimationSpeed = 0.03F;
            this.btnFileDel.BaseColor = System.Drawing.Color.Transparent;
            this.btnFileDel.BorderColor = System.Drawing.Color.Black;
            this.btnFileDel.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnFileDel.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnFileDel.CheckedForeColor = System.Drawing.Color.White;
            this.btnFileDel.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btnFileDel.CheckedImage")));
            this.btnFileDel.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnFileDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnFileDel.FocusedColor = System.Drawing.Color.Empty;
            this.btnFileDel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFileDel.ForeColor = System.Drawing.Color.White;
            this.btnFileDel.Image = global::GzLauncher.Properties.Resources.DelGameSelected;
            this.btnFileDel.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnFileDel.ImageSize = new System.Drawing.Size(5, 5);
            this.btnFileDel.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnFileDel.Location = new System.Drawing.Point(226, 0);
            this.btnFileDel.Name = "btnFileDel";
            this.btnFileDel.OnHoverBaseColor = System.Drawing.Color.Red;
            this.btnFileDel.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnFileDel.OnHoverForeColor = System.Drawing.Color.White;
            this.btnFileDel.OnHoverImage = null;
            this.btnFileDel.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnFileDel.OnPressedColor = System.Drawing.Color.Black;
            this.btnFileDel.Size = new System.Drawing.Size(25, 20);
            this.btnFileDel.TabIndex = 2;
            this.btnFileDel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.btnFileDel);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.fileIconPic);
            this.Name = "FileControl";
            this.Size = new System.Drawing.Size(250, 100);
            ((System.ComponentModel.ISupportInitialize)(this.fileIconPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox fileIconPic;
        private Guna.UI.WinForms.GunaLabel lblFileName;
        private Guna.UI.WinForms.GunaAdvenceButton btnFileDel;
    }
}
