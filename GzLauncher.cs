using GzLauncher.Classes;
using IWshRuntimeLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;


namespace GzLauncher
{
    public partial class GzLauncher : Form
    {

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams CP = base.CreateParams;
        //        CP.ExStyle = CP.ExStyle | 0x02000000; // WS_EX_COMPOSITED
        //        return CP;
        //    }
        //}



        private int limit = 9;
        private int offset = 0;
        private bool canScroll = false;
        private int limitOnlineFix = 15;
        private int offsetOnlineFix = 0;
        private bool canScrollOnlineFix = false;
        private readonly Database DB = new Database();
        private readonly Profile profile = new Profile();
        private readonly Scrapper scrapper = new Scrapper();
        private string selectedLibraryGame = string.Empty;
        private int lastMessageID = 0;
        private FlowLayoutPanel flpOnlineFixTemp = new FlowLayoutPanel();
        private FlowLayoutPanel flpStoreTemp = new FlowLayoutPanel();
        private FlowLayoutPanel flpReleaseTemp = new FlowLayoutPanel();
        private FlowLayoutPanel flpDownloadTemp = new FlowLayoutPanel();
        private FlowLayoutPanel flpLibraryTemp = new FlowLayoutPanel();
        private FlowLayoutPanel flpPreviewsTemp = new FlowLayoutPanel();
        public GzLauncher()
        {
          
            InitializeComponent();
      
        }

        private void GzLauncher_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;
            this.Shown += new EventHandler(GzLauncher_Shown);
            flpOnlineFixTemp = this.flpOnlineFix;
            flpStoreTemp = this.flpStore;
            flpReleaseTemp = this.flpReleases;
            flpDownloadTemp = this.flpDownload;
            flpLibraryTemp = this.flpLibrary;
            flpPreviewsTemp = this.flpPreviews;


        }

        private Task initProfile()
        {
            // Remove Invoke
            lblUserName.Invoke((Action) delegate
           {
                ArrayList profileData = profile.GetProfileData();
                float opacity = float.Parse(profileData[3].ToString(), CultureInfo.InvariantCulture.NumberFormat);
             lblUserName2.Text = profileData[0].ToString();
            lblUserName.Text = profileData[0].ToString();
            profilePicBox.Image = Classes.UI.GetImageFromURL(profileData[1].ToString());
            profilePicBox2.Image = Classes.UI.GetImageFromURL(profileData[1].ToString());

            //storePanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
            //libraryPanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
            //downloadsPanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
            //communityPanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
            //profilePanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
            //   releasesPanel.BackgroundImage = Classes.UI.SetImageOpacity(UI.GetImageFromURL(profileData[2].ToString()), opacity);
          });
            return Task.CompletedTask;
        }

        public async void initProfileAsync()
        {
           

                await Task.Run(() => initProfile());
           
         
        }

        private void FlpMain_Scroll(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0)
            {

            }
            else
            {

                if (canScroll == true)
                {
                    canScroll = false;
                    LoadStoreThreaded();

                    offset = offset + limit;
                    Console.WriteLine(offset);
                }
            }


        }

        private void FlpOnlineFix_Scroll(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {

            }
            else
            {

                if (canScrollOnlineFix == true)
                {
                    canScrollOnlineFix = false;
                    LoadOnlineFixThreaded();

                    offsetOnlineFix = offsetOnlineFix + limitOnlineFix;
                    Console.WriteLine(offsetOnlineFix);
                }
            }
        }

        private void GzLauncher_Shown(object sender, EventArgs e)
        {


            this.Invoke((MethodInvoker) delegate {
                Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


                Thread th = new Thread(() =>

                {


                    this.Invoke((MethodInvoker)(() =>   // It works!
                    {
                        this.Invoke((Action)delegate
                        {

                            dispatcherUI.BeginInvoke(
                             DispatcherPriority.Background,
                             new Action(() => load()));


                        });
                    }));

                });
                th.SetApartmentState(ApartmentState.MTA);
                th.IsBackground = true; // 
                th.Start();
            });
          
            

        }

        private Task load()
        {
            initProfileAsync();
            flpStore.MouseWheel += new MouseEventHandler(FlpMain_Scroll);
            flpOnlineFix.MouseWheel += new MouseEventHandler(FlpOnlineFix_Scroll);

            setDragables();
            LoadStoreThreaded();
            LoadLibraryThreaded();
            LoadDownloadsThreaded();
            LoadOnlineFixThreaded();
            LoadReleasesThreaded();
            fetchMessageTimer.Enabled = true;
          
            return Task.CompletedTask;
        }

     

        /// Loading Store //

        private void LoadStoreThreaded()
        {
           
            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpStore.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => LoadStoreFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }


        private void LoadStoreFunc()
        {
            flpStore.Invoke((Action)async delegate
            {
               
                    canScroll = await Task.Run(() => LoadStore());
            });

        }

        private async Task<bool> LoadStore()
        {
            canScroll = false;
            dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields name, first_release_date, total_rating, cover; where platforms = 6 & total_rating > 79; sort first_release_date desc;limit " + limit+"; offset "+offset+";");

            foreach (dynamic res in response)
            {
                flpStoreTemp.Invoke((Action)async delegate
                {
                    try
                    {
                        await Task.Run(() => UI.LoadStore(res["id"].ToString(),IGDB.FetchCoverImage(res["cover"].ToString()), res["name"].ToString(), flpStoreTemp));
                    } catch
                    {

                    }
                  
                });

            }

            return await Task.FromResult(true);
        }

        // Loading Store ///


        /// Search Store //


        private async Task<bool> SearchStore()
        {
            canScroll = false;
            dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields *; search \"" + txtStoreSearch.Text + "\"; where category = 0; limit 8;");

        

            foreach (dynamic res in response)
            {
                flpStoreTemp.Invoke((Action)async delegate
                {
                    try
                    {
                        await Task.Run(() => UI.LoadStore(res["id"].ToString(), IGDB.FetchCoverImage(res["cover"].ToString()), res["name"].ToString(), flpStoreTemp));
                    }
                    catch
                    {

                    }

                });

            }

            return await Task.FromResult(true);
        }

        private void SearchStoreFunc()
        {
            flpStoreTemp.Invoke((Action)async delegate
            {

                await Task.Run(() => SearchStore());
            });

        }

        private void SearchStoreThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpStoreTemp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => SearchStoreFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }


        // Search Store ///


        /// Loading OnlineFix //

        private void LoadOnlineFixThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpStore.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => LoadOnlineFixFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }


        private void LoadOnlineFixFunc()
        {
            flpStore.Invoke((Action)async delegate
            {

                canScrollOnlineFix = await Task.Run(() => LoadOnlineFix());
            });

        }

        private async Task<bool> LoadOnlineFix()
        {
            canScrollOnlineFix = false;
         await BoxAPI.refreshToken();
            dynamic response = BoxAPI.getFiles(offsetOnlineFix, limitOnlineFix);
            

            foreach (dynamic res in response["entries"])
            {
                flpOnlineFix.Invoke((Action)async delegate
                {
                    try
                    {
                        await Task.Run(() => UI.LoadOnlineFix(res["id"].ToString(), res["name"].ToString(), ".rar", flpOnlineFixTemp));
                    }
                    catch
                    {

                    }

                });
       


            }

            return await Task.FromResult(true);
        }


        // Loading OnlineFix ///


        /// Searching OnlineFix //
        private async Task<bool> SearchOnlineFix()
        {
            dynamic search = BoxAPI.searchFile(txtOnlineFixSearch.Text);

            foreach (dynamic res in search["entries"])
            {

                flpOnlineFixTemp.Invoke((Action)async delegate
                {
                    try
                    {

                        await Task.Run(() => UI.LoadOnlineFix(res["id"].ToString(), res["name"].ToString(), ".rar", flpOnlineFixTemp));

                    }
                    catch
                    {

                    }

                });

                ;
            }

            return await Task.FromResult(true);
        }

        private void SearchOnlineFixFunc()
        {
            flpOnlineFixTemp.Invoke((Action)async delegate
            {

              await Task.Run(() => SearchOnlineFix());
            });

        }


        private void SearchOnlineFixThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpOnlineFixTemp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => SearchOnlineFixFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }


        // Searching OnlineFix ///

        /// Loading Library //

        private async Task<bool> LoadLibrary()
        {

            ArrayList gameList = DB.getDataFromDatabase("SELECT * FROM Library ORDER BY Id DESC");

            foreach (DataRow item in gameList)
            {
                flpLibraryTemp.Invoke((Action)async delegate
                {
                    try
                    {
                        await Task.Run(() => UI.LoadLibrary(item[0].ToString(), item[3].ToString(), item[2].ToString(), item[4].ToString(), flpLibraryTemp));
                    }
                    catch
                    {

                    }

                });

            }

            return await Task.FromResult(true);
        }


        private void LoadLibraryFunc()
        {
            flpLibraryTemp.Invoke((Action)async delegate
            {

                await Task.Run(() => LoadLibrary());
            });

        }

        private void LoadLibraryThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpLibraryTemp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => LoadLibraryFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }

        public void addGameToLibrary(string id, string name, string cover, string path)
        {
            UI.LoadLibrary(id, cover, name, path, flpLibraryTemp);
        }

        private void flpLibrary_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;

            string name = string.Empty;
            string path = string.Empty;
            string cover = string.Empty;
            string igdbid = string.Empty;
            try {
                string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                foreach(var file in fileList)
                {
                  
                    switch (Path.GetExtension(file))
                    {
                        case ".lnk":
                            name = Path.GetFileNameWithoutExtension(file);
                            WshShell shell = new WshShell();
                            IWshShortcut link = (IWshShortcut)shell.CreateShortcut(file);

                            path = link.GetType().FullName;

                            path = link.TargetPath;



                            break;


                        case ".url":
                             name = Path.GetFileNameWithoutExtension(file);
                            WshShell shell1 = new WshShell();
                            IWshURLShortcut link1 = (IWshURLShortcut)shell1.CreateShortcut(file);
                            path = link1.TargetPath;

                          
                            break;
                    }

                    dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields *; search \"" + name + "\"; where category = 0;");
                    igdbid = response[0]["id"];
                    cover = IGDB.FetchCoverImage(response[0]["cover"].ToString());

                    List<KeyValuePair<string, string>> game = new List<KeyValuePair<string, string>>();
                    List<GzGame> gameObject = new List<GzGame>
                            {
                                new GzGame() {igdbid = igdbid, name = name, cover = cover, path = path}
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
                    addGameToLibrary(igdbid, name, cover, path);
                    MessageBox.Show("Game Added to Library!");


                }
                
               
            } catch
            {

            }
        }


        public void changeLibraryGame(string id)
        {
            selectedLibraryGame = id;
        }

        public void updateLibraryControl(string id, string cover, string gamename, string path)
        {
            UI.updateControlUI(id, flpLibraryTemp, cover, gamename, path);
        }

        // Loading Library ///


        /// Loading Downloads //

        private async Task<bool> LoadDownloads()
        {

            System.Linq.IOrderedEnumerable<string> paths = Classes.File.listFiles(Environment.CurrentDirectory + @"\Downloads");

            foreach (string path in paths)
            {
                int pos = path.LastIndexOf(@"\");
                string filename = path.Substring(pos + 1);
                string filextension = Path.GetExtension(path);
                flpDownloadTemp.Invoke((Action)async delegate
                {
                    try
                    {
                        await Task.Run(() => UI.LoadDownloads(path, filename, filextension, flpDownloadTemp));
                    }
                    catch
                    {

                    }

                });

            }

            return await Task.FromResult(true);
        }

        private void LoadDownloadsFunc()
        {
            flpDownloadTemp.Invoke((Action)async delegate
            {

                await Task.Run(() => LoadDownloads());
            });

        }

        public void LoadDownloadsThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpDownloadTemp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => LoadDownloadsFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }

      

        public void clearDownloads()
        {
            downloadsPanel.Controls.Remove(flpDownload);
            downloadsPanel.Controls.Remove(flpDownloadTemp);
        }

  



        // Loading Downloads ///

        /// Loading Releases //

        private async Task<bool> LoadReleases()
        {

            HtmlAgilityPack.HtmlNodeCollection releases = scrapper.fetchReleases();

            foreach (var item in releases)
            {
                flpReleaseTemp.Invoke((Action)async delegate
                {
                    await Task.Run(() => UI.LoadReleases(flpReleaseTemp, item.InnerText));


                });
                
            }

            return await Task.FromResult(true);
        }

        private void LoadReleasesFunc()
        {
            flpReleaseTemp.Invoke((Action)async delegate
            {

                await Task.Run(() => LoadReleases());
            });

        }

        public void LoadReleasesThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flpReleaseTemp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => LoadReleasesFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }

        // Loading Releases ///


        /// Chat //

        private void fetchMessageTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                FetchMessageThreaded();
            }
            catch
            {

            }
         

        }

        private async Task<bool> FetchMessage()
        {

            if (lastMessageID == 0)
            {
                string[] data = Chat.FetchLastMessage();
                lastMessageID = Int32.Parse(data[0]);

                // Console.WriteLine(data[0] + " " + data[2]);
            }
            else
            {

                await Task.Run(() => Chat.FetchMessage(lastMessageID));
            }

            return await Task.FromResult(true);
        }

        public void addMessagetoUI(ChatControl chatControl)
        {
            flpChat.Invoke((Action)delegate
            {

                flpChat.Controls.Add(chatControl);

                flpChat.AutoScrollPosition = new Point(chatControl.Left, chatControl.Top);
            });



        }

        private async void FetchMessageFunc()
        {


            await Task.Run(() => FetchMessage());


        }

        private void FetchMessageThreaded()
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    this.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => FetchMessageFunc()));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }



        public void changeLastMessageId(int id)
        {
            this.lastMessageID = id;
        }

        private void btnSendMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                try
                {
                    Chat.SendMessage(lblUserName.Text, txtSendMsg.Text);
                    txtSendMsg.Text = string.Empty;
                }
                catch
                {

                }
               
             
            }
        }

        // Chat ///




        /// Menu Option Click Event

        private void MenuOption_Click(Object sender, EventArgs e)
        {
            var button = (Guna.UI.WinForms.GunaAdvenceButton)sender;

            switch (button.Name)
            {
                case "btnLibrary":
                    libraryPanel.BringToFront();
                    break;

                case "btnStore":

                    storePanel.BringToFront();
                    break;

                case "btnOnlineFix":
                    onlineFixPanel.BringToFront();
                    break;

                case "btnDownloads":
                    clearDownloads();
                    FlowLayoutPanel flpDownloads = new FlowLayoutPanel();
                    flpDownloads.Size = new Size(909, 622);
                    flpDownloads.Location = new Point(27, 76);
                    flpDownloads.AutoScroll = true;
                    flpDownloadTemp = flpDownloads;
                    downloadsPanel.Controls.Add(flpDownloadTemp);

                    LoadDownloadsThreaded(); 
                    downloadsPanel.BringToFront();
                    break;

                case "btnCommunity":
                    communityPanel.BringToFront();
                    break;

                case "btnProfile":
                    profilePanel.BringToFront();
                    break;

                case "btnReleases":
                    releasesPanel.BringToFront();
                    break;

            }
        }

        // Menu Option Click Event ///


        /// Interactive Click Events //
        
        private void btnAddGame_Click(object sender, EventArgs e)
        {
            AddGame addGame = new AddGame();
            addGame.ShowDialog();
        }



 

        private void btnEditGame_Click(object sender, EventArgs e)
        {
            if (selectedLibraryGame != string.Empty)
            { 
            AddGame addGame = new AddGame(false, selectedLibraryGame);
            addGame.ShowDialog();
            }
        }

        private void btnEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile editProfile = new EditProfile();
            editProfile.ShowDialog();
        }

        private void btnDelGame_Click(object sender, EventArgs e)
        {
            if (selectedLibraryGame != string.Empty)
            {
                DB.deleteFromDatabase("Library", Int32.Parse(selectedLibraryGame));
            UI.delControlUI(selectedLibraryGame, flpLibrary);
            MessageBox.Show("Game deleted from Library!");
            }
        }

        private void txtLibrarySearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (txtLibrarySearch.Text != string.Empty)
                {
                    removeFlpLibrary();
                    FlowLayoutPanel flpLibrary = new FlowLayoutPanel();

                    flpLibrary.Size = new Size(909, 622);
                    flpLibrary.Location = new Point(27, 76);
                    flpLibrary.AutoScroll = true;

                    flpLibraryTemp = flpLibrary;

                    libraryPanel.Controls.Add(flpLibraryTemp);

                    ArrayList searchLibraryGames = DB.getDataFromDatabase("SELECT * FROM Library WHERE (name LIKE '" + txtLibrarySearch.Text + "%')" + " ORDER BY Id DESC");

                    foreach (DataRow item in searchLibraryGames)
                    {


                        UI.LoadLibrary(item[0].ToString(), item[3].ToString(), item[2].ToString(), item[4].ToString(), flpLibraryTemp);

                    }
                }
                else
                {
                    removeFlpLibrary();
                    FlowLayoutPanel flpLibrary = new FlowLayoutPanel();

                    flpLibrary.Size = new Size(909, 622);
                    flpLibrary.Location = new Point(27, 76);
                    flpLibrary.AutoScroll = true;

                    flpLibraryTemp = flpLibrary;

                    libraryPanel.Controls.Add(flpLibraryTemp);

                    LoadLibraryThreaded();
                }
        

            }
        }

        private void txtDownloadSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
               
                if (txtDownloadSearch.Text != string.Empty)
                {

                    clearDownloads();
                    FlowLayoutPanel flpDownloads = new FlowLayoutPanel();

                    flpDownloads.Size = new Size(909, 622);
                    flpDownloads.Location = new Point(27, 76);
                    flpDownloads.AutoScroll = true;

                    flpDownloadTemp = flpDownloads;
       
                    downloadsPanel.Controls.Add(flpDownloadTemp);

                    System.Linq.IOrderedEnumerable<string> paths = Classes.File.listFiles(Environment.CurrentDirectory + @"\Downloads");

                    foreach (string path in paths)
                    {
                        int pos = path.LastIndexOf(@"\");
                        string filename = path.Substring(pos + 1);
                        string filextension = Path.GetExtension(path);
                        flpDownloadTemp.Invoke((Action)async delegate
                        {
                            try
                            {
                                if (filename.Contains(txtDownloadSearch.Text))
                                {
                                    await Task.Run(() => UI.LoadDownloads(path, filename, filextension, flpDownloadTemp));
                                }
                            }
                            catch
                            {

                            }

                        });

                    }
                }
                else
                {
                    clearDownloads();
                    FlowLayoutPanel flpDownloads = new FlowLayoutPanel();

                    flpDownloads.Size = new Size(909, 622);
                    flpDownloads.Location = new Point(27, 76);
                    flpDownloads.AutoScroll = true;
    
                    flpDownloadTemp = flpDownloads;

                    downloadsPanel.Controls.Add(flpDownloadTemp);
                    LoadDownloadsThreaded();
                }
            }
        }

        private void removeFlpOnlineFix()
        {
            onlineFixPanel.Controls.Remove(this.flpOnlineFix);

            onlineFixPanel.Controls.Remove(flpOnlineFixTemp);
        }

        private void removeFlpStore()
        {
            storePanel.Controls.Remove(this.flpStore);

            storePanel.Controls.Remove(flpStoreTemp);
        }

        private void removeFlpLibrary()
        {
            libraryPanel.Controls.Remove(this.flpLibrary);

            libraryPanel.Controls.Remove(flpLibraryTemp);
        }

        private  void txtStoreSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (txtStoreSearch.Text == string.Empty)
                {
                    removeFlpStore();
                    FlowLayoutPanel flpStore = new FlowLayoutPanel();

                    flpStore.Size = new Size(909, 622);
                    flpStore.Location = new Point(27, 76);
                    flpStore.AutoScroll = true;

                    flpStoreTemp = flpStore;
                    flpStoreTemp.MouseWheel += FlpMain_Scroll;
                    storePanel.Controls.Add(flpStoreTemp);
                    offset = 0;
                    limit = 8;
                    LoadStoreThreaded();
                }
                else
                {
                    removeFlpStore();
                    FlowLayoutPanel flpStore = new FlowLayoutPanel();

                    flpStore.Size = new Size(909, 622);
                    flpStore.Location = new Point(27, 76);
                    flpStore.AutoScroll = true;

                    flpStoreTemp = flpStore;
                    storePanel.Controls.Add(flpStoreTemp);
                    SearchStoreThreaded();
                }

            }
        }

        private void txtOnlineFixSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                if (txtOnlineFixSearch.Text == string.Empty)
                {
                    removeFlpOnlineFix();
                    FlowLayoutPanel flpOnlineFix = new FlowLayoutPanel();

                    flpOnlineFix.Size = new Size(909, 622);
                    flpOnlineFix.Location = new Point(27, 76);
                    flpOnlineFix.AutoScroll = true;

                    flpOnlineFixTemp = flpOnlineFix;
                    flpOnlineFixTemp.MouseWheel += FlpOnlineFix_Scroll;
                    onlineFixPanel.Controls.Add(flpOnlineFixTemp);
                    offsetOnlineFix = 0;
                    limitOnlineFix = 15;
                    LoadOnlineFixThreaded();
                }
                else
                {
                    removeFlpOnlineFix();

                    FlowLayoutPanel flpOnlineFix = new FlowLayoutPanel();

                    flpOnlineFix.Size = new Size(909, 622);
                    flpOnlineFix.Location = new Point(27, 76);
                    flpOnlineFix.AutoScroll = true;
              
                    flpOnlineFixTemp = flpOnlineFix;
                    onlineFixPanel.Controls.Add(flpOnlineFixTemp);
                    SearchOnlineFixThreaded();


                }

              
            }
        }

        private void btnRefreshReleases_Click(object sender, EventArgs e)
        {
            releasesPanel.Controls.Remove(flpReleases);
            releasesPanel.Controls.Remove(flpReleaseTemp);
            FlowLayoutPanel flpReleases1 = new FlowLayoutPanel();

            flpReleases1.Size = new Size(810, 622);
            flpReleases1.Location = new Point(154, 78);
            flpReleases1.AutoScroll = true;

            flpReleaseTemp = flpReleases1;
            releasesPanel.Controls.Add(flpReleaseTemp);
            LoadReleasesThreaded();
        }

        // Interactive Click Events ///

        /// Others //

        private void setDragables()
        {
            Guna.UI.WinForms.GunaDragControl downloadPanelDrag = new Guna.UI.WinForms.GunaDragControl();
            downloadPanelDrag.TargetControl = downloadsPanel;

            Guna.UI.WinForms.GunaDragControl downloadPanelFlpDrag = new Guna.UI.WinForms.GunaDragControl();
            downloadPanelFlpDrag.TargetControl = flpDownload;

            Guna.UI.WinForms.GunaDragControl libraryPanelDrag = new Guna.UI.WinForms.GunaDragControl();
            libraryPanelDrag.TargetControl = libraryPanel;

            Guna.UI.WinForms.GunaDragControl libraryPanelFlpDrag = new Guna.UI.WinForms.GunaDragControl();
            libraryPanelFlpDrag.TargetControl = flpLibrary;

            Guna.UI.WinForms.GunaDragControl storePanelDrag = new Guna.UI.WinForms.GunaDragControl();
            storePanelDrag.TargetControl = storePanel;

            Guna.UI.WinForms.GunaDragControl storePanelFlpDrag = new Guna.UI.WinForms.GunaDragControl();
            storePanelFlpDrag.TargetControl = flpStore;


            Guna.UI.WinForms.GunaDragControl communityPanelDrag = new Guna.UI.WinForms.GunaDragControl();
            communityPanelDrag.TargetControl = communityPanel;

            Guna.UI.WinForms.GunaDragControl communityPanelFlpDrag = new Guna.UI.WinForms.GunaDragControl();
            communityPanelFlpDrag.TargetControl = flpChat;

            Guna.UI.WinForms.GunaDragControl profilePanelDrag = new Guna.UI.WinForms.GunaDragControl();
            profilePanelDrag.TargetControl = profilePanel;

            Guna.UI.WinForms.GunaDragControl releasePanelDrag = new Guna.UI.WinForms.GunaDragControl();
            releasePanelDrag.TargetControl = releasesPanel;

            Guna.UI.WinForms.GunaDragControl releasePanelFlpDrag = new Guna.UI.WinForms.GunaDragControl();
            releasePanelFlpDrag.TargetControl = flpReleases;

            Guna.UI.WinForms.GunaDragControl previewPanel = new Guna.UI.WinForms.GunaDragControl();
            previewPanel.TargetControl = gameViewPanel;


        }

        private Task setGameDataPrev(string img, string summ, string genre, string date, string title)
        {
           
            lblGameDesc.Invoke((Action) delegate
            {
                gunaPictureBox5.ImageLocation = img;
                lblGameDesc.Text = summ;
                lblGameGenre.Text = genre;
                lblReleaseDate.Text = date;
                lblGameTitle.Text = title;
            });
            return Task.CompletedTask;
         
        }

        public Task getGameData(string id)
        {
            dynamic response = IGDB.IGDBResponse("https://api.igdb.com/v4/games/", "Bearer " + IGDB.GenerateAccessToken(), "fields *; where id = " + id + ";");
            lblGameDesc.Invoke((Action)async delegate
            {
                await Task.Run(() => setGameDataPrev(IGDB.FetchArtworkImage(response[0]["screenshots"][0].ToString()), response[0]["summary"].ToString(), IGDB.FetchGenre(response[0]["genres"][0].ToString()), UnixTime.ToLocalDateTime(double.Parse(response[0]["first_release_date"].ToString())).ToString(), response[0]["name"].ToString()));
                gameViewPanel.Controls.Remove(flpPreviewsTemp);
                gameViewPanel.Controls.Remove(flpPreviews);
                FlowLayoutPanel flpP = new FlowLayoutPanel();

                flpP.Size = new Size(860, 100);
                flpP.Location = new Point(27, 346);
                flpP.AutoScroll = true;
                flpP.WrapContents = false;
                flpPreviewsTemp = flpP;
                gameViewPanel.Controls.Add(flpPreviewsTemp);
                int i = 0;
                foreach (dynamic item in response[0]["screenshots"])
                {
                    i++;
                    Guna.UI.WinForms.GunaPictureBox gunaPictureBox = new Guna.UI.WinForms.GunaPictureBox();
                    gunaPictureBox.ImageLocation = IGDB.FetchArtworkImage(item.ToString());
                    gunaPictureBox.Size = new Size(120, 80);
                    gunaPictureBox.Click += new EventHandler(preview_click);
                    flpPreviewsTemp.Controls.Add(gunaPictureBox);
                    if (i == 6)
                    {
                        break;
                    }
                    
                }
                gameViewPanel.BringToFront();
            });
            return Task.CompletedTask;


        }

        private void preview_click(object sender, EventArgs e)
        {
            var dGControl = (Guna.UI.WinForms.GunaPictureBox)sender;
            gunaPictureBox5.ImageLocation = dGControl.ImageLocation;
        }

        private void getGameDataFunc(string id)
        {
            lblGameDesc.Invoke((Action)async delegate
            {

                await Task.Run(() => getGameData(id));
            });

        }

        public void getGameDataThreaded(string id)
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                this.Invoke((MethodInvoker)(() =>   // It works!
                {
                    lblGameDesc.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => getGameDataFunc(id)));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }



 





        // Others ///



    }




}
