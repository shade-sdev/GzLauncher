using Newtonsoft.Json;
using RestSharp;

namespace GzLauncher.Classes
{
    class IGDB
    {

        public static dynamic IGDBResponse(string url, string accesstoken, string body)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Client-ID", Constants.IGDB_CLIENT_ID);
            request.AddHeader("Authorization", accesstoken);
            request.AddHeader("Cookie", "__cfduid=dde30d03974d8beb32ce41e422f3551fc1616172455");
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

            IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            return jsonResponse;
        }


        public static string GenerateAccessToken()
        {
            var client = new RestClient("https://id.twitch.tv/oauth2/token?client_id=" + Constants.IGDB_CLIENT_ID + "&client_secret=" + Constants.IGDB_SECRET + "&grant_type=client_credentials");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse response = client.Execute(request);
            dynamic jsonResponse = JsonConvert.DeserializeObject(response.Content);
            return jsonResponse["access_token"];
        }

        public static string FetchCoverImage(string coverid)
        {
          

            dynamic response = IGDBResponse("https://api.igdb.com/v4/covers", "Bearer " + GenerateAccessToken(), "fields *; where id =" + coverid + ";");
            string imageurl = response[0]["url"];
            imageurl = "https:" + imageurl;
            imageurl = imageurl.Replace("t_thumb", "t_cover_big");

            return imageurl;
        }

        public static string FetchArtworkImage(string artworkid)
        {


            dynamic response = IGDBResponse("https://api.igdb.com/v4/screenshots", "Bearer " + GenerateAccessToken(), "fields *; where id =" + artworkid + ";");
            string imageurl = response[0]["url"];
            imageurl = "https:" + imageurl;
            imageurl = imageurl.Replace("t_thumb", "t_screenshot_huge");

            return imageurl;
        }

        public static string FetchGenre(string genreid)
        {
            dynamic response = IGDBResponse("https://api.igdb.com/v4/genres", "Bearer " + GenerateAccessToken(), "fields *; where id =" + genreid + ";");
            string genre = response[0]["name"];
            return genre;
        }

    }
}
