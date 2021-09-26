namespace GzLauncher
{
    partial class ChatControl
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
            this.lblUserName = new Guna.UI.WinForms.GunaLabel();
            this.lblMessage = new Guna.UI.WinForms.GunaLabel();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.lblDate = new Guna.UI.WinForms.GunaLabel();
            this.gunaElipsePanel1 = new Guna.UI.WinForms.GunaElipsePanel();
            this.gunaElipsePanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Silver;
            this.lblUserName.Location = new System.Drawing.Point(21, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(434, 18);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Shade";
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Roboto Lt", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblMessage.Location = new System.Drawing.Point(9, 8);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(859, 40);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Hello";
            // 
            // gunaSeparator1
            // 
            this.gunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(74)))));
            this.gunaSeparator1.Location = new System.Drawing.Point(0, 89);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(912, 10);
            this.gunaSeparator1.TabIndex = 2;
            this.gunaSeparator1.Visible = false;
            // 
            // lblDate
            // 
            this.lblDate.Font = new System.Drawing.Font("Roboto Lt", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Silver;
            this.lblDate.Location = new System.Drawing.Point(784, 10);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(109, 18);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "17/09/2021 22:10";
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // gunaElipsePanel1
            // 
            this.gunaElipsePanel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaElipsePanel1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            this.gunaElipsePanel1.Controls.Add(this.lblMessage);
            this.gunaElipsePanel1.Location = new System.Drawing.Point(20, 35);
            this.gunaElipsePanel1.Name = "gunaElipsePanel1";
            this.gunaElipsePanel1.Size = new System.Drawing.Size(871, 48);
            this.gunaElipsePanel1.TabIndex = 4;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.Controls.Add(this.gunaElipsePanel1);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.gunaSeparator1);
            this.Controls.Add(this.lblUserName);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(912, 95);
            this.gunaElipsePanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaLabel lblUserName;
        private Guna.UI.WinForms.GunaLabel lblMessage;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaLabel lblDate;
        private Guna.UI.WinForms.GunaElipsePanel gunaElipsePanel1;
    }
}
