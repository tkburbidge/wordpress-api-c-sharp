using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace WordPressApiClient
{
    public class WordPressApiJwtAuthenticator : JwtAuthenticator, IAuthenticator
    {
        private string accessToken;

        public WordPressApiJwtAuthenticator(string accessToken) : base(accessToken)
        {
            this.accessToken = accessToken;
        }

        public async static Task<WordPressApiJwtAuthenticator> Create(Uri siteUrl, string username, string password)
        {
            RestClient client = new RestClient(siteUrl);
            RestRequest request = new RestRequest("/wp-json/jwt-auth/v1/token", Method.POST);
            request.AddParameter("username", username);
            request.AddParameter("password", password);

            var tokenResponse = await client.ExecuteTaskAsync<JwtTokenResponse>(request);
            if (tokenResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return new WordPressApiJwtAuthenticator(tokenResponse.Data.Token);
            }

            throw new Exception("Authentication failed", tokenResponse.ErrorException);
        }

        private class JwtTokenResponse
        {
            public string Token { get; set; }
            public string UserDisplayName { get; set; }
            public string UserEmail { get; set; }
            public string UserNicename { get; set; }
        }
    }
}
