namespace GzLauncher
{
    partial class EditProfile
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
            this.components = new System.ComponentModel.Container();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.lblUserName = new Guna.UI.WinForms.GunaLabel();
            this.txtUserName = new Guna.UI.WinForms.GunaTextBox();
            this.lblProfileImage = new Guna.UI.WinForms.GunaLabel();
            this.txtProfileImage = new Guna.UI.WinForms.GunaTextBox();
            this.lblBgImage = new Guna.UI.WinForms.GunaLabel();
            this.txtBGImage = new Guna.UI.WinForms.GunaTextBox();
            this.btnEditProfile = new Guna.UI.WinForms.GunaAdvenceButton();
            this.lblBGOpacity = new Guna.UI.WinForms.GunaLabel();
            this.txtBGOpacity = new Guna.UI.WinForms.GunaTextBox();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(362, -1);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.Red;
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(45, 29);
            this.gunaControlBox1.TabIndex = 0;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Roboto Th", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Location = new System.Drawing.Point(30, 37);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(61, 15);
            this.lblUserName.TabIndex = 4;
            this.lblUserName.Text = "Username";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtUserName.BorderColor = System.Drawing.Color.Silver;
            this.txtUserName.BorderSize = 0;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtUserName.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtUserName.FocusedForeColor = System.Drawing.Color.White;
            this.txtUserName.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(31, 58);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.Radius = 4;
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(338, 40);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.TextOffsetX = 10;
            // 
            // lblProfileImage
            // 
            this.lblProfileImage.AutoSize = true;
            this.lblProfileImage.Font = new System.Drawing.Font("Roboto Th", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProfileImage.ForeColor = System.Drawing.Color.White;
            this.lblProfileImage.Location = new System.Drawing.Point(33, 112);
            this.lblProfileImage.Name = "lblProfileImage";
            this.lblProfileImage.Size = new System.Drawing.Size(75, 15);
            this.lblProfileImage.TabIndex = 6;
            this.lblProfileImage.Text = "Profile Image";
            // 
            // txtProfileImage
            // 
            this.txtProfileImage.BackColor = System.Drawing.Color.Transparent;
            this.txtProfileImage.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtProfileImage.BorderColor = System.Drawing.Color.Silver;
            this.txtProfileImage.BorderSize = 0;
            this.txtProfileImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtProfileImage.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtProfileImage.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtProfileImage.FocusedForeColor = System.Drawing.Color.White;
            this.txtProfileImage.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProfileImage.ForeColor = System.Drawing.Color.White;
            this.txtProfileImage.Location = new System.Drawing.Point(31, 133);
            this.txtProfileImage.Name = "txtProfileImage";
            this.txtProfileImage.PasswordChar = '\0';
            this.txtProfileImage.Radius = 4;
            this.txtProfileImage.SelectedText = "";
            this.txtProfileImage.Size = new System.Drawing.Size(338, 40);
            this.txtProfileImage.TabIndex = 5;
            this.txtProfileImage.TextOffsetX = 10;
            // 
            // lblBgImage
            // 
            this.lblBgImage.AutoSize = true;
            this.lblBgImage.Font = new System.Drawing.Font("Roboto Th", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBgImage.ForeColor = System.Drawing.Color.White;
            this.lblBgImage.Location = new System.Drawing.Point(33, 190);
            this.lblBgImage.Name = "lblBgImage";
            this.lblBgImage.Size = new System.Drawing.Size(58, 15);
            this.lblBgImage.TabIndex = 8;
            this.lblBgImage.Text = "BG Image";
            // 
            // txtBGImage
            // 
            this.txtBGImage.BackColor = System.Drawing.Color.Transparent;
            this.txtBGImage.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtBGImage.BorderColor = System.Drawing.Color.Silver;
            this.txtBGImage.BorderSize = 0;
            this.txtBGImage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBGImage.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtBGImage.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtBGImage.FocusedForeColor = System.Drawing.Color.White;
            this.txtBGImage.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBGImage.ForeColor = System.Drawing.Color.White;
            this.txtBGImage.Location = new System.Drawing.Point(31, 211);
            this.txtBGImage.Name = "txtBGImage";
            this.txtBGImage.PasswordChar = '\0';
            this.txtBGImage.Radius = 4;
            this.txtBGImage.SelectedText = "";
            this.txtBGImage.Size = new System.Drawing.Size(338, 40);
            this.txtBGImage.TabIndex = 7;
            this.txtBGImage.TextOffsetX = 10;
            // 
            // btnEditProfile
            // 
            this.btnEditProfile.AnimationHoverSpeed = 0.07F;
            this.btnEditProfile.AnimationSpeed = 0.03F;
            this.btnEditProfile.BackColor = System.Drawing.Color.Transparent;
            this.btnEditProfile.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEditProfile.BorderColor = System.Drawing.Color.Black;
            this.btnEditProfile.CheckedBaseColor = System.Drawing.Color.Gray;
            this.btnEditProfile.CheckedBorderColor = System.Drawing.Color.Black;
            this.btnEditProfile.CheckedForeColor = System.Drawing.Color.White;
            this.btnEditProfile.CheckedImage = global::GzLauncher.Properties.Resources.GameSearch;
            this.btnEditProfile.CheckedLineColor = System.Drawing.Color.DimGray;
            this.btnEditProfile.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEditProfile.FocusedColor = System.Drawing.Color.Empty;
            this.btnEditProfile.Font = new System.Drawing.Font("Russo One", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProfile.ForeColor = System.Drawing.Color.LightGray;
            this.btnEditProfile.Image = null;
            this.btnEditProfile.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditProfile.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEditProfile.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnEditProfile.Location = new System.Drawing.Point(107, 354);
            this.btnEditProfile.Name = "btnEditProfile";
            this.btnEditProfile.OnHoverBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEditProfile.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEditProfile.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEditProfile.OnHoverImage = null;
            this.btnEditProfile.OnHoverLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(58)))), ((int)(((byte)(170)))));
            this.btnEditProfile.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.btnEditProfile.Radius = 4;
            this.btnEditProfile.Size = new System.Drawing.Size(178, 38);
            this.btnEditProfile.TabIndex = 14;
            this.btnEditProfile.Text = "EDIT PROFILE";
            this.btnEditProfile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEditProfile.Click += new System.EventHandler(this.btnEditProfile_Click);
            // 
            // lblBGOpacity
            // 
            this.lblBGOpacity.AutoSize = true;
            this.lblBGOpacity.Font = new System.Drawing.Font("Roboto Th", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBGOpacity.ForeColor = System.Drawing.Color.White;
            this.lblBGOpacity.Location = new System.Drawing.Point(33, 267);
            this.lblBGOpacity.Name = "lblBGOpacity";
            this.lblBGOpacity.Size = new System.Drawing.Size(64, 15);
            this.lblBGOpacity.TabIndex = 16;
            this.lblBGOpacity.Text = "BG Opacity";
            // 
            // txtBGOpacity
            // 
            this.txtBGOpacity.BackColor = System.Drawing.Color.Transparent;
            this.txtBGOpacity.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtBGOpacity.BorderColor = System.Drawing.Color.Silver;
            this.txtBGOpacity.BorderSize = 0;
            this.txtBGOpacity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBGOpacity.FocusedBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.txtBGOpacity.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtBGOpacity.FocusedForeColor = System.Drawing.Color.White;
            this.txtBGOpacity.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBGOpacity.ForeColor = System.Drawing.Color.White;
            this.txtBGOpacity.Location = new System.Drawing.Point(31, 288);
            this.txtBGOpacity.Name = "txtBGOpacity";
            this.txtBGOpacity.PasswordChar = '\0';
            this.txtBGOpacity.Radius = 4;
            this.txtBGOpacity.SelectedText = "";
            this.txtBGOpacity.Size = new System.Drawing.Size(338, 40);
            this.txtBGOpacity.TabIndex = 15;
            this.txtBGOpacity.TextOffsetX = 10;
            // 
            // EditProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(407, 422);
            this.Controls.Add(this.lblBGOpacity);
            this.Controls.Add(this.txtBGOpacity);
            this.Controls.Add(this.btnEditProfile);
            this.Controls.Add(this.lblBgImage);
            this.Controls.Add(this.txtBGImage);
            this.Controls.Add(this.lblProfileImage);
            this.Controls.Add(this.txtProfileImage);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.gunaControlBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditProfile";
            this.Load += new System.EventHandler(this.EditProfile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        private Guna.UI.WinForms.GunaLabel lblBgImage;
        private Guna.UI.WinForms.GunaTextBox txtBGImage;
        private Guna.UI.WinForms.GunaLabel lblProfileImage;
        private Guna.UI.WinForms.GunaTextBox txtProfileImage;
        private Guna.UI.WinForms.GunaLabel lblUserName;
        private Guna.UI.WinForms.GunaTextBox txtUserName;
        private Guna.UI.WinForms.GunaAdvenceButton btnEditProfile;
        private Guna.UI.WinForms.GunaLabel lblBGOpacity;
        private Guna.UI.WinForms.GunaTextBox txtBGOpacity;
    }
}