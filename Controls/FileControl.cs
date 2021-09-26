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
    public partial class FileControl : UserControl
    {
        public FileControl()
        {
            InitializeComponent();
        }

        public Guna.UI.WinForms.GunaPictureBox picBox
        {
            get
            {
                return fileIconPic;
            }

            set
            {
                fileIconPic = value;
            }
        }


        public Guna.UI.WinForms.GunaLabel lblName
        {
            get { return lblFileName; }
            set { lblFileName = value; }
        }

        public Guna.UI.WinForms.GunaAdvenceButton btnFileDelete
        {
            get { return btnFileDel; }
            set { btnFileDel = value; }
        }
    }
}
