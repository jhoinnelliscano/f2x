using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using UploadData.F2x.Model;

namespace UploadData.F2x
{
    public static class CallServiceHelper
    {
        private static readonly string ApiUrl = "http://54.209.174.241:5200";
        private static string Token { get; set; } = null;

        public static string GetToken() 
        {
            if (string.IsNullOrEmpty(Token))
                 GetNewToken();

            return Token;
        }

        public static void GetNewToken()
        {
            var method = "api/Login";
            var client = new RestClient(ApiUrl);

            var authRequest = new AuthRequest()
            {
                UserName = "user",
                Password = "1234"
            };

            var requestService = new RestRequest(method, Method.Post);
            requestService.AddJsonBody(authRequest);

            var response = client.Post(requestService);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<AuthResponse>(response.Content);
                Token = result.Token;
            }
        }

        public static IList<VehicleResponse> GetConteoVehiculos(string date)
        {
            var method = "api/ConteoVehiculos/" + date;
            var client = new RestClient(ApiUrl);
            var token = GetToken();
            var authenticator = new JwtAuthenticator(token);

            var requestService = new RestRequest(method, Method.Get) 
            {
                Authenticator = authenticator 
            };

            var response = client.Get(requestService);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<IList<VehicleResponse>>(response.Content);
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                 GetNewToken();
                 GetConteoVehiculos(date);
            }

            return null;
        }

        public static IList<VehicleResponse> GetRecaudoVehiculos(string date)
        {
            var method = "api/RecaudoVehiculos/" + date;
            var client = new RestClient(ApiUrl);
            var token =  GetToken();
            var authenticator = new JwtAuthenticator(token);

            var requestService = new RestRequest(method, Method.Get)
            {
                Authenticator = authenticator
            };

            var response =  client.Get(requestService);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var result = JsonConvert.DeserializeObject<IList<VehicleResponse>>(response.Content);
                return result;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                 GetNewToken();
                 GetConteoVehiculos(date);
            }

            return null;
        }
    }
}
