using GzLauncher.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GzLauncher
{
    public partial class EditProfile : Form
    {
        private readonly Profile profile = new Profile();
        private readonly Database DB = new Database();
        public EditProfile()
        {
            InitializeComponent();
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            List<KeyValuePair<string, string>> user = new List<KeyValuePair<string, string>>();
            List<User> userObject = new List<User>
            {
                new User() {username = txtUserName.Text, imagelocation=txtProfileImage.Text, imagebg = txtBGImage.Text, bgopacity = float.Parse(txtBGOpacity.Text)}
            };

            foreach (var data in userObject)
            {

                user.Clear();
                foreach (var item in data.GetType().GetProperties())
                {
                    user.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                }
            }
            DB.updateToDatabase(user, "[User]", 1);

            var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
            gzLauncherForm.initProfileAsync();
            this.Close();
        }

        private void EditProfile_Load(object sender, EventArgs e)
        {
            ArrayList profileData = profile.GetProfileData();

            txtUserName.Text = profileData[0].ToString();
            txtProfileImage.Text = profileData[1].ToString();
            txtBGImage.Text = profileData[2].ToString();
            txtBGOpacity.Text= profileData[3].ToString();
        }
    }
}
