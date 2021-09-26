using GzLauncher.Classes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
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
    public partial class AddGame : Form
    {

        private readonly Database DB = new Database();
        private bool insert = true;
        private string id = "";

        public AddGame(bool insert = true, string id = "")
        {
            InitializeComponent();

            if (insert == true)
            {

            }else
                if(insert == false)
            {
                this.insert = false;
                this.id = id;
            }
        }

        private void AddGame_Load(object sender, EventArgs e)
        {
            if (insert == false)
            {
                lblAddGame.Text = "EDIT GAME";
                btnAddGame.Text = "EDIT GAME";
                ArrayList gameData = DB.getDataFromDatabase("SELECT * FROM Library WHERE id = "+ id);
                  foreach(DataRow item in gameData)
                        {
                    txtGameName.Tag = item[1].ToString();
                    txtGameName.Text = item[2].ToString();
                    txtCoverURL.Text = item[3].ToString();
                    txtPath.Text = item[4].ToString();
                }
            


            }else
                if (insert == true)
            {
                lblAddGame.Text = "ADD GAME";
                btnAddGame.Text = "ADD GAME";
            }
        }

        private async void btnSearchGameData_Click(object sender, EventArgs e)
        {
            await Task.Run(() => searchGameData());

        }

        private Task searchGameData()
        {
            cmbType.Invoke((Action) async delegate
            {
                
            switch (cmbType.SelectedIndex)
            {
                case 0:
                        await Task.Run(() => FetchSteam());
                        break;


                case 4:
                        await Task.Run(() => FetchCrack());
                        break;
            }

          
            });
            
            return Task.FromResult(true);
        }

        private Task FetchCrack()
        {
           dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields *; search \"" + txtGameName.Text + "\"; where category = 0;");

            txtGameName.Tag = response[0]["id"];
            txtGameName.Text = response[0]["name"];
            txtCoverURL.Text = IGDB.FetchCoverImage(response[0]["cover"].ToString());
            MessageBox.Show("Searched!");
            return Task.FromResult(true);
        }

        private Task FetchSteam()
        {
           dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields *; search \"" + txtGameName.Text + "\"; where category = 0;");
            this.Invoke((Action) delegate
            {
                try
                {
                    txtGameName.Tag = response[0]["id"];
                    txtGameName.Text = response[0]["name"];
                    txtCoverURL.Text = IGDB.FetchCoverImage(response[0]["cover"].ToString());
                }
                catch
                {

                }

            });
      


            foreach (string[] array in SteamAppIDFinder.Finder.result(SteamAppIDFinder.Finder.getResponse(), txtGameName.Text))
            {
                Console.WriteLine(array[1]);
                var client = new RestClient("https://store.steampowered.com/api/appdetails/?appids="+array[1]);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
                IRestResponse response1 = client.Execute(request);
                dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

      
                 try
                {
                    if (jsonResponse[array[1]]["data"]["type"].ToString() == "game")
                    {
                        this.Invoke((Action)delegate
                        {
                            try
                            {
                                txtPath.Text = "steam://rungameid/" + array[1];
                              
                            }
                            catch
                            {

                            }

                        });
                        break;
                    }
                }
                catch
                {

                }
                




            }
            MessageBox.Show("Searched!");
            return Task.FromResult(true);
        }



        private void btnPathDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseExe = new OpenFileDialog();
            chooseExe.Filter = "EXECUTABLE | *.exe";
            chooseExe.ShowDialog();
            txtPath.Text = chooseExe.FileName;
        }

        private void btnAddGame_Click(object sender, EventArgs e)
        {
          if (insert == true)
            {
                List<KeyValuePair<string, string>> game = new List<KeyValuePair<string, string>>();
                List<GzGame> gameObject = new List<GzGame>
            {
                new GzGame() {igdbid = txtGameName.Tag.ToString(), name = txtGameName.Text, cover = txtCoverURL.Text, path = txtPath.Text}
            };

                foreach (var data in gameObject)
                {

                    game.Clear();
                    foreach (var item in data.GetType().GetProperties())
                    {
                        game.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                    }
                }

                DB.insertToDatabase(game, "Library");
                var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
                gzLauncherForm.addGameToLibrary(txtGameName.Tag.ToString(), txtGameName.Text, txtCoverURL.Text, txtPath.Text);
                MessageBox.Show("Game Added to Library!");



                this.Close();
            }else
                if(insert == false)
            {
                List<KeyValuePair<string, string>> game = new List<KeyValuePair<string, string>>();

        

           

                    List<GzGame> gameObject = new List<GzGame>
            {
                new GzGame() {igdbid = txtGameName.Tag.ToString(), name = txtGameName.Text, cover = txtCoverURL.Text, path = txtPath.Text}
            };

                    foreach (var data in gameObject)
                    {

                        game.Clear();
                        foreach (var item in data.GetType().GetProperties())
                        {
                            game.Add(new KeyValuePair<string, string>(item.Name, item.GetValue(data).ToString()));
                        }
                    }
                

                DB.updateToDatabase(game, "Library", Int32.Parse(id));
                var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
                gzLauncherForm.updateLibraryControl(id, txtCoverURL.Text, txtGameName.Text, txtPath.Text);
                MessageBox.Show("Game Updated to Library!");
               
            }
        }

     
    }
}
