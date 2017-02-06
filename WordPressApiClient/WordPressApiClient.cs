using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressApiClient.Models;

namespace WordPressApiClient
{
    public class WordPressApiClient
    {
        private Uri siteUrl;
        private RestClient restClient;

        public WordPressApiClient(Uri siteUrl, IAuthenticator authenticator)
        {
            this.siteUrl = siteUrl;
            this.restClient = new RestClient(siteUrl);
            this.restClient.Authenticator = authenticator;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            RestRequest request = new RestRequest("/wp-json/wp/v2/users", Method.GET);

            return await getResponseAsync<List<User>>(request);
        }

        public async Task CreateUserAsync(User user)
        {
            RestRequest request = new RestRequest("/wp-json/wp/v2/users", Method.POST);

            await getResponseAsync(request);
        }

        private async Task getResponseAsync(RestRequest request)
        {
            var response = await this.restClient.ExecuteTaskAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception("Request failed", response.ErrorException);
            }
        }

        private async Task<T> getResponseAsync<T>(RestRequest request)
        {
            var response = await this.restClient.ExecuteTaskAsync<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }

            throw new Exception("Request failed", response.ErrorException);
        }

        //public List<User> GetUsers()
        //{
        //    RestRequest request = new RestRequest("/wp-json/wp/v2/users");

        //    var response = this.restClient.ExecuteTaskAsync<List<User>>(request);
        //    if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    {
        //        return response.Data;
        //    }

        //    throw new Exception("Request failed", response.ErrorException);
        //}
    }
}
