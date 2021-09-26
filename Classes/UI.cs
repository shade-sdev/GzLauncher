using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace GzLauncher.Classes
{



    class UI
    {
        private static DGControl selectedStoreItem = null;
        private static LGControl selectedLibraryItem = null;

        //       Image image = GetImageFromPicPath("https://wallpaperaccess.com/full/384208.jpg");
        //       Panel.BackgroundImage = SetImageOpacity(image, 0.1F);

        // StorePanel = 909, 622
        // Location = 25, 78

        public static Image SetImageOpacity(Image image, float opacity)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                ColorMatrix matrix = new ColorMatrix();
                matrix.Matrix33 = opacity;
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default,
                                                  ColorAdjustType.Bitmap);
                g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                                   0, 0, image.Width, image.Height,
                                   GraphicsUnit.Pixel, attributes);
            }
            return bmp;
        }
        public static Image GetImageFromPicPath(string strUrl)
        {
            using (WebResponse wrFileResponse = WebRequest.Create(strUrl).GetResponse())
            using (Stream objWebStream = wrFileResponse.GetResponseStream())
            {
                MemoryStream ms = new MemoryStream();
                objWebStream.CopyTo(ms, 8192);
                return System.Drawing.Image.FromStream(ms);
            }
        }

        public static Image GetImageFromURL(string url)
        {
            Image image = GetImageFromPicPath(url);
            return image;
        }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    e.Graphics.DrawLine(Pens.Yellow, 0, 0, 100, 100);
        //}

        public static Task LoadStore(string name,string imageLocation, string gameName, FlowLayoutPanel flpMain)
        {
            DGControl dGControl = new DGControl();
            dGControl.Name = name;
            dGControl.picBox.Name = name;
            dGControl.picBox.Tag = gameName;
            dGControl.picBox.Click += new EventHandler(StoreItem_Click);
            dGControl.picBox.DoubleClick += new EventHandler(Store_Item_DoubleClick);
            dGControl.Margin = new Padding(10, 0, 5, 10);
            dGControl.picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            dGControl.picBox.ImageLocation = imageLocation;
            dGControl.picBox.Radius = 4;
            dGControl.colorBG = Color.Red;
            dGControl.GameName.ForeColor = Color.White;
            dGControl.GameName.Text = gameName;
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                {
                    flpMain.Controls.Add(dGControl);
                }

                ));
           
            });
  

            return Task.CompletedTask;
        }

        public static Task LoadOnlineFix(string id, string filename, string filextension, FlowLayoutPanel flpMain)
        {
            OFControl fileControl = new OFControl();
            fileControl.Margin = new Padding(25, 0, 5, 10);
            fileControl.Name = id;
            fileControl.lblName.Name = id;
            fileControl.picBox.BackgroundImage = Classes.File.getFileIcon(filextension);
            fileControl.lblName.Text = filename;
            fileControl.DoubleClick += OnlineFix_DoubleClick;
            fileControl.lblName.DoubleClick += OnlineFixText_DoubleClick;
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                 {
                     flpMain.Controls.Add(fileControl);
                 }

                ));

            });

            return Task.CompletedTask;
        }


        public static Task LoadLibrary(string id, string imageLocation, string gameName, string path, FlowLayoutPanel flpMain)
        {
            LGControl dGControl = new LGControl();
            dGControl.Name = id;
            dGControl.picBox.Name = id;
            dGControl.picBox.Tag = path;
            dGControl.picBox.Click += new EventHandler(LibraryItem_Click);
            dGControl.picBox.DoubleClick += new EventHandler(Library_Item_DoubleClick);
            dGControl.Margin = new Padding(10, 0, 5, 10);
            dGControl.picBox.SizeMode = PictureBoxSizeMode.StretchImage;
            dGControl.picBox.ImageLocation = imageLocation;
            dGControl.picBox.Radius = 4;
            dGControl.colorBG = Color.Red;
            dGControl.GameName.ForeColor = Color.White;
            dGControl.GameName.Text = gameName;
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                 {
                     flpMain.Controls.Add(dGControl);
                 }

                ));

            });

            return Task.CompletedTask;
        }

        public static Task LoadDownloads(string path, string filename, string filextension, FlowLayoutPanel flpMain)
        {
            FileControl fileControl = new FileControl();
            fileControl.Margin = new Padding(25, 0, 5, 10);
            fileControl.Name = path;
            fileControl.lblName.Name = path;
            fileControl.btnFileDelete.Name = path;
            fileControl.picBox.BackgroundImage = Classes.File.getFileIcon(filextension);
            fileControl.lblName.Text = filename;
            fileControl.DoubleClick += FileControl_DoubleClick;
            fileControl.lblName.DoubleClick += LblName_DoubleClick;
            fileControl.btnFileDelete.Click += BtnFileDelete_Click;
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                 {
                     flpMain.Controls.Add(fileControl);
                 }

                ));

            });

            return Task.CompletedTask;
        }

        public static Task LoadMessages(string username,string message, FlowLayoutPanel flpMain)
        {
            ChatControl chatControl = new ChatControl();

            chatControl.setMessage.Text = message;
            chatControl.setUserName.Text = username;
    
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                 {
                     flpMain.Controls.Add(chatControl);
                 }

                ));

            });

            return Task.CompletedTask;
        }

        public static Task LoadReleases(FlowLayoutPanel flpMain, string releasename)
        {
            RLControl rLControl = new RLControl();
            rLControl.setReleaseName.Text = releasename;
            rLControl.Margin = new Padding(0);
        
            flpMain.Invoke((Action)async delegate
            {

                await Task.Run(() =>
                 flpMain.Invoke((Action)delegate
                 {
                     flpMain.Controls.Add(rLControl);
                 }

                ));

            });

            return Task.CompletedTask;
        }

        private static void BtnFileDelete_Click(object sender, EventArgs e)
        {
            var fileControl_btnDel = (Guna.UI.WinForms.GunaAdvenceButton)sender;
            System.IO.File.Delete(fileControl_btnDel.Name);
        

            FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)fileControl_btnDel.Parent.Parent;
            FileControl fileControl = (FileControl)fileControl_btnDel.Parent;
            flowLayoutPanel.Controls.Remove(fileControl);



        }

        private static void LblName_DoubleClick(object sender, EventArgs e)
        {
            var fileControl_lbl = (Guna.UI.WinForms.GunaLabel)sender;
            Process.Start(fileControl_lbl.Name);
        }

        private static void OnlineFixText_DoubleClick(object sender, EventArgs e)
        {
            BoxAPI.refreshToken();
            var onlineFixLabel = (Guna.UI.WinForms.GunaLabel)sender;
            dynamic response = BoxAPI.getShareLink(onlineFixLabel.Name);
      
            Process.Start(new ProcessStartInfo { FileName = response["shared_link"]["url"].ToString(), UseShellExecute = true });

        }

        private static void OnlineFix_DoubleClick(object sender, EventArgs e)
        {
               BoxAPI.refreshToken();
            var onlineFixLabel = (OFControl)sender;
            dynamic response = BoxAPI.getShareLink(onlineFixLabel.Name);
      
            Process.Start(new ProcessStartInfo { FileName = response["shared_link"]["url"].ToString(), UseShellExecute = true });

        }

        private static void FileControl_DoubleClick(object sender, EventArgs e)
        {
            var fileControl = (FileControl)sender;
            Process.Start(fileControl.Name);
        }

        private static void StoreItem_Click(object sender, EventArgs e)
        {
            var dGControl = (Guna.UI.WinForms.GunaPictureBox)sender;

           
            if (selectedStoreItem != null)
            {
                selectedStoreItem.colorBG = Color.Red;
            }

    
            DGControl dGControl1 = (DGControl)dGControl.Parent.Parent;
            dGControl1.colorSelect = Color.Red;
            selectedStoreItem = dGControl1;
            var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
            gzLauncherForm.getGameDataThreaded(dGControl1.Name);
     
            //Console.WriteLine(response[0]["storyline"]);
            //Console.WriteLine(IGDB.FetchArtworkImage(response[0]["screenshots"][0].ToString()));
            //Console.WriteLine(IGDB.FetchGenre(response[0]["genres"][0].ToString()));
            //Console.WriteLine(dGControl.Name);

      
           
        }

    

    

        private static void LibraryItem_Click(object sender, EventArgs e)
        {
            var dGControl = (Guna.UI.WinForms.GunaPictureBox)sender;

            if (selectedLibraryItem != null)
            {
                selectedLibraryItem.colorBG = Color.Red;
            }

            LGControl dGControl1 = (LGControl)dGControl.Parent.Parent;
            dGControl1.colorSelect = Color.Red;
            selectedLibraryItem = dGControl1;
                        
                        var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
                        gzLauncherForm.changeLibraryGame(dGControl.Name);
          



        }
        private static void Library_Item_DoubleClick(object sender, EventArgs e)
        {
            var dGControl = (Guna.UI.WinForms.GunaPictureBox)sender;


            if (dGControl.Tag.ToString().Contains("steam://rungameid/") || dGControl.Tag.ToString().Contains("com.epicgames.launcher://apps/") || dGControl.Tag.ToString().Contains("shell"))
            {
                Process.Start(dGControl.Tag.ToString());
            } else
            {
                int pos = dGControl.Tag.ToString().LastIndexOf(@"\");
                string workingDirectory = dGControl.Tag.ToString().Substring(0, pos);
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = dGControl.Tag.ToString();
                info.WorkingDirectory = workingDirectory;
                Process.Start(info);
            }

         
        }

        private static void Store_Item_DoubleClick(object sender, EventArgs e)
        {
            var dGControl = (Guna.UI.WinForms.GunaPictureBox)sender;
            Scrapper scrapper = new Scrapper();
            scrapper.dllAsync(dGControl.Tag.ToString());
         


        }

        public static Task clearFPTask(FlowLayoutPanel flp, Control item)
        {
            flp.Controls.Remove(item);
            return Task.CompletedTask;
        }

        public static async Task<bool> clearFlp<T>(FlowLayoutPanel flp) where T : Control
        {

            foreach (Control item in flp.Controls.OfType<T>())
            {
                item.Invoke((Action)async delegate
                {
                    await clearFPTask(flp, item);
                });
             
            }

            flp.Controls.Clear();

            return await Task.FromResult(true);
        }

        private static async void clearFlpFunc<T>(FlowLayoutPanel flp) where T : Control
        {
          

              await Task.Run(() => clearFlp<Control>(flp));
         

        }


        public static void ClearFlpThreaded<T>(FlowLayoutPanel flp) where T : Control
        {

            Dispatcher dispatcherUI = Dispatcher.CurrentDispatcher;


            Thread th = new Thread(() =>

            {


                flp.Invoke((MethodInvoker)(() =>   // It works!
                {
                    flp.Invoke((Action)delegate
                    {

                        dispatcherUI.BeginInvoke(
                         DispatcherPriority.Background,
                         new Action(() => clearFlpFunc<Control>(flp)));


                    });
                }));

            });
            th.SetApartmentState(ApartmentState.MTA);
            th.IsBackground = true; // 
            th.Start();
        }

        public static void updateControlUI(string id, FlowLayoutPanel flp, string cover, string gamename, string path)
        {
            foreach(LGControl lGControl in flp.Controls)
            {
                if(lGControl.Name == id)
                {
                    lGControl.Name = id;
                    lGControl.picBox.Tag = path;
                    lGControl.GameName.Text = gamename;
                    lGControl.picBox.ImageLocation = cover;
                }
            }
        }

        public static void delControlUI(string id, FlowLayoutPanel flp)
        {
            foreach (LGControl lGControl in flp.Controls)
            {
                if (lGControl.Name == id)
                {
                    flp.Controls.Remove(lGControl);
                }
            }
        }



    }
}
