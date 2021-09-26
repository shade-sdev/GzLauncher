using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzLauncher.Classes
{
    class Profile
    {
        private readonly Database DB = new Database();
        public ArrayList GetProfileData()
        {
            ArrayList profileDataSend = new ArrayList();
            ArrayList profileData = DB.getDataFromDatabase("SELECT * FROM [User] WHERE Id = 1");
            foreach (DataRow row in profileData)
            {
                profileDataSend.Add(row[1].ToString());
                profileDataSend.Add(row[2].ToString());
                profileDataSend.Add(row[3].ToString());
                profileDataSend.Add(row[4].ToString());
            }
            //string[] profileData1 = new string[2] { profileData[0].ToString(), ""};
            return profileDataSend;
        }
    }
}
