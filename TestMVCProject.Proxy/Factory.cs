using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace TestMVCProject.Proxy
{
    public class Factory
    {
        private static readonly string APIKEY = "92a08465539a47f993a06ef09f74b3cf";

        private static Factory _instance;

        public static Factory Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Factory();
                return _instance;
            }
        }


        public List<Article> GetLatestNews()
        {

            var newsapiClient = new NewsApiClient(APIKEY);
            var articalResponse = newsapiClient.GetTopHeadlines(new TopHeadlinesRequest
            {
                Country = Countries.IN,
                Category = Categories.Technology

            });
            if (articalResponse.Status == Statuses.Ok)
            {
                return articalResponse.Articles;
            }
            else
            {
                throw new InvalidOperationException(articalResponse.Error.Message);
            }
        }

        public async System.Threading.Tasks.Task<string> GetJSONPlaceholderRecordsAsync()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();
            var response  = await client.GetAsync(url);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return response.ReasonPhrase;
            }
        }
    }
}
