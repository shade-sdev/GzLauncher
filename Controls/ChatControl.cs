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
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }

        public Guna.UI.WinForms.GunaLabel setUserName
        {
            get{ return lblUserName; }
            set { lblUserName = value; }
        }

        public Guna.UI.WinForms.GunaLabel setMessage
        {
            get { return lblMessage; }
            set { lblMessage = value; }
        }

        public Guna.UI.WinForms.GunaLabel setDate
        {
            get { return lblDate; }
            set { lblDate = value; }
        }
    }
}
