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
    public partial class RLControl : UserControl
    {
        public RLControl()
        {
            InitializeComponent();
        }

        public Guna.UI.WinForms.GunaLabel setReleaseName
        {
            get { return lblReleaseName; }
            set { lblReleaseName = value; }
        }
    }
}
