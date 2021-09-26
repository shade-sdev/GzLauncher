
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GzLauncher.Classes
{
    class Scrapper
    {
        string search = "";
        private string getURL(string baseURL = "https://www.skidrowreloaded.com/")
        {
            string url = "";

            try
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.skidrowreloaded.com/?s=" + baseURL);
                foreach (var item in doc.DocumentNode.SelectNodes("//div[@class='post']//h2//a"))
                {



                    url = item.Attributes["href"].Value;
                    break;


                }
            }
            catch
            {
                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load("https://torrentgalaxy.to/torrents.php?search=" + baseURL + "&lang=0&nox=2&sort=size&order=desc");

                var item = doc.DocumentNode.SelectNodes("//div[@class='tgxtablecell collapsehide rounded txlight']//a[contains(@href,'https://watercache')]");
                url = item[0].Attributes["href"].Value;
            }


            return url;
        }


        private string getDownloadURL(string downloadURL)
        {
            string dloadURL = "";

            if (downloadURL.Contains("skidrowreloaded"))
            {



                HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = web.Load(downloadURL);
                try
                {
                    foreach (var item in doc.DocumentNode.SelectNodes("//div//a[contains(@href,'file.html')]"))
                    {

                        dloadURL = item.Attributes["href"].Value;

                    }
                }
                catch (System.NullReferenceException e)
                {
                    try
                    {
                        HtmlAgilityPack.HtmlWeb web2 = new HtmlAgilityPack.HtmlWeb();
                        HtmlAgilityPack.HtmlDocument doc2 = web.Load("https://torrentgalaxy.to/torrents.php?search=" + search + "&lang=0&nox=2&sort=size&order=desc");

                        var item2 = doc2.DocumentNode.SelectNodes("//div[@class='tgxtablecell collapsehide rounded txlight']//a[contains(@href,'https://watercache')]");
                        dloadURL = item2[0].Attributes["href"].Value;
                    }
                    catch (System.NullReferenceException ex)
                    {
                        try
                        {
                            foreach (var item in doc.DocumentNode.SelectNodes("//div//a[contains(@href,'clicknupload')]"))
                            {

                                dloadURL = item.Attributes["href"].Value;

                            }
                        }
                        catch (System.NullReferenceException ez)
                        {
                            try
                            {
                                foreach (var item in doc.DocumentNode.SelectNodes("//div//a[contains(@href,'mediafire')]"))
                                {

                                    dloadURL = item.Attributes["href"].Value;

                                }
                            }
                            catch (System.NullReferenceException ezz)
                            {
                                try
                                {
                                    foreach (var item in doc.DocumentNode.SelectNodes("//div//a[contains(@href,'fastclick')]"))
                                    {

                                        dloadURL = item.Attributes["href"].Value;

                                    }
                                }
                                catch
                                {
                                    MessageBox.Show("No URL found!");
                                }
                            }

                        }


                    }

                }

            }
            else
            {
                dloadURL = downloadURL;
            }
            return dloadURL;
        }

        private void downloadTorrent(string dloadURL, string gamename)
        {



            if (dloadURL.Contains("zippyshare"))
            {

                try
                {

                    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load(dloadURL);

                    foreach (var item in doc.DocumentNode.SelectNodes("//script[contains(text(),'dlbutton')]"))
                    {


                        var jsPattern = @"document.getElementById\(\s*'(?<key>[^']+)'\s*\)\s*\.\s*href\s*=\s*" + @"""(?<href>[^']+)""";
                        var jsRegex = new Regex(jsPattern);


                        var matches = jsRegex.Matches(item.InnerHtml);


                        var match = matches[0];
                        var href = match.Groups["href"].ToString();
                        int index = href.IndexOf('"');
                        string firstpart = href.Substring(0, index);


                        string cal = href.Split('(', ')')[1];
                        int index2 = cal.IndexOf('+');
                        string calpart1 = cal.Substring(0, index2).Trim();
                        string calpart2 = cal.Substring(cal.LastIndexOf('+') + 1);
                        int num1 = Int32.Parse(calpart1.Substring(0, calpart1.IndexOf('%')));
                        int num2 = Int32.Parse(calpart1.Substring(calpart1.LastIndexOf('%') + 1));
                        int num3 = Int32.Parse(calpart2.Substring(0, calpart2.IndexOf('%')));
                        int num4 = Int32.Parse(calpart2.Substring(calpart2.LastIndexOf('%') + 1));
                        int finalNum = (num1 % num2) + (num3 % num4);
                        string thirdpart = href.Substring(href.LastIndexOf('"' + "/") + 1);
                        string finalpart = firstpart + finalNum + thirdpart;



                        WebClient wb = new WebClient();
                        wb.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/46.0.2490.33 Safari/537.36");
                        wb.DownloadFile(dloadURL.Substring(0, dloadURL.IndexOf("/v/")) + finalpart, Environment.CurrentDirectory + "/Downloads/" + thirdpart);

                        MessageBox.Show("Torrent File Downloaded!");
                    }

                }
                catch
                {
                    HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
                    HtmlAgilityPack.HtmlDocument doc = web.Load("https://torrentgalaxy.to/torrents.php?search=" + search + "&lang=0&nox=2&sort=size&order=desc");

                    var item = doc.DocumentNode.SelectNodes("//div[@class='tgxtablecell collapsehide rounded txlight']//a[contains(@href,'https://watercache')]");
                    using (var client = new WebClient())
                    {
                        client.DownloadFile(item[0].Attributes["href"].Value, Environment.CurrentDirectory + "/Downloads/" + gamename + ".torrent");
                    }

                    MessageBox.Show("Torrent File Downloaded!");

                }

            }
            else

            if (dloadURL.Contains("watercache"))
            {
                using (var client = new WebClient())
                {
                    client.DownloadFile(dloadURL, Environment.CurrentDirectory + "/Downloads/" + gamename + ".torrent");
                }

                MessageBox.Show("Torrent File Downloaded!");
            }
            else
            {
                Process.Start(dloadURL);
            }
        }


        private void dllFunc(string gamename)
        {
            string sanitizeSearch = gamename.Replace(" ", "+");
            search = sanitizeSearch;
            downloadTorrent(getDownloadURL(getURL(sanitizeSearch)), gamename);
        }

        public async void dllAsync(string gamename)
        {
            string sanitizeGamename = gamename.Replace(":", "");
            await Task.Run(() => dllFunc(sanitizeGamename));

        }


        public HtmlAgilityPack.HtmlNodeCollection fetchReleases()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://predb.me/?cats=games-pc");

            return doc.DocumentNode.SelectNodes("//div[@class='p-c p-c-title']//h2//a");
        }


    }
}
