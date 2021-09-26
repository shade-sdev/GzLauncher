namespace GzLauncher
{
    partial class RLControl
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
            this.components = new System.ComponentModel.Container();
            this.lblReleaseName = new Guna.UI.WinForms.GunaLabel();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.SuspendLayout();
            // 
            // lblReleaseName
            // 
            this.lblReleaseName.Font = new System.Drawing.Font("Roboto Lt", 11F);
            this.lblReleaseName.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblReleaseName.Location = new System.Drawing.Point(17, 0);
            this.lblReleaseName.Name = "lblReleaseName";
            this.lblReleaseName.Size = new System.Drawing.Size(567, 35);
            this.lblReleaseName.TabIndex = 0;
            this.lblReleaseName.Text = "Alders.Blood.Definitive.Edition-CODEX";
            this.lblReleaseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.gunaSeparator1.Location = new System.Drawing.Point(0, 28);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(600, 10);
            this.gunaSeparator1.TabIndex = 1;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.TargetControl = this;
            // 
            // RLControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.Controls.Add(this.gunaSeparator1);
            this.Controls.Add(this.lblReleaseName);
            this.Name = "RLControl";
            this.Size = new System.Drawing.Size(600, 35);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel lblReleaseName;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}
