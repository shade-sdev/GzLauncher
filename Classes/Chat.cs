using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GzLauncher.Classes
{
    class Chat
    {

        public static void SendMessage(string userid, string message)
        {
            var client = new RestClient(Constants.CHATAPI_HOST+"/api.php?userid="+userid+"&message="+message+"&date="+DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
           
     

        }


        public static Task FetchMessage(int id)
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/api.php?id=" + id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            foreach(dynamic message in jsonResponse)
            {
                if(id != Int32.Parse(message["id"].ToString()))
                {
                    var gzLauncherForm = Application.OpenForms.OfType<GzLauncher>().FirstOrDefault();
                    gzLauncherForm.changeLastMessageId(Int32.Parse(message["id"].ToString()));
                    ChatControl chatControl = new ChatControl();
                    chatControl.Margin = new Padding(0);
                    chatControl.setMessage.Text = message["message"];
                    chatControl.setUserName.Text = message["userid"];
                    chatControl.setDate.Text = message["date"];
                    gzLauncherForm.addMessagetoUI(chatControl);
                   // Console.WriteLine(message["id"]+" "+message["message"]);
                }
                
            }

            return Task.CompletedTask;
        }

        public static string[] FetchLastMessage()
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/api.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            string[] data = new string[4] { jsonResponse[0]["id"], jsonResponse[0]["userid"], jsonResponse[0]["message"], jsonResponse[0]["date"] };

            return data;
            
        }

    }
}
