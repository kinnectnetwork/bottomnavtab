using App2.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace App2.Models
{
    public class SearchResultLogic
    {

        public static async void GetData()
        {
            using (HttpClient client = new HttpClient())
            {
                var url = "http://localhost:59994/api/SearchResult?ZUMO-API-VERSION=2.0.0&ownUserId=AD31EC52-5A07-A176-4195-8526FCB919EF&searchType=Peer&resultCount=5";
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }
        }

        public async static Task<List<SearchResult>> GetSearchResults()
        {
            List<SearchResult> searchResults = new List<SearchResult>();

            string url = "http://localhost:59994/api/SearchResult?ZUMO-API-VERSION=2.0.0&ownUserId=AD31EC52-5A07-A176-4195-8526FCB919EF&searchType=Peer&resultCount=5";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();
            }

            return searchResults;
        }
    }

    public class SearchResult
    {
        public string id { get; set; }
    }

    public class SearchResultRoot
    {
        public static string GenerateURL()
        {
            return (string.Format(Constants.PROFILE_SEARCH, Constants.OWNUSERID, Constants.SEARCHTYPE, Constants.RESULTCOUNT));
        }
    }
}
