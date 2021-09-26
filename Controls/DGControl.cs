using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GzLauncher
{
    public partial class DGControl : UserControl
    {
        public DGControl()
        {
            InitializeComponent();
        }

        public System.Drawing.Color colorBG
        {
            get { return SelectPanel.BackColor; }

            set
            {

                SelectPanel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            }

        }

        public System.Drawing.Color colorSelect
        {
            get { return SelectPanel.BackColor; }

            set
            {

                SelectPanel.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(40)))), ((int)(((byte)(41)))));
            }

        }

        public Guna.UI.WinForms.GunaPictureBox picBox
        {
            get
            {
                return CoverImage;
            }

            set
            {
                CoverImage = value;
            }
        }

        public Guna.UI.WinForms.GunaLabel GameName
        {
            get
            {
                return lblGameName;
            }
            set
            {
                lblGameName = value;
            }
        }

    }
}
