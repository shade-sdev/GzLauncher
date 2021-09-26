using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GzLauncher.Classes
{
    class BoxAPI
    {

        public static dynamic getFiles(int offset, int limit)
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/BoxAPI/api.php?list=all&offset="+offset+"&limit="+limit);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            return jsonResponse;
        }

        public static Task refreshToken()
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/BoxAPI/api.php");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            return Task.CompletedTask;
        }

        public static dynamic getShareLink(string id)
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/BoxAPI/api.php?share=" +id);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            return jsonResponse;
        }

        public static dynamic searchFile(string search)
        {
            var client = new RestClient(Constants.CHATAPI_HOST + "/BoxAPI/api.php?search=" + search);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response1 = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response1.Content);

            return jsonResponse;
        }

    }
}
