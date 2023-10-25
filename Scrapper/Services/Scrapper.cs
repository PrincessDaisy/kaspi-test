using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Scrapper.Services
{
    public class Scrapper : IScrapper
    {
        private readonly IHttpClientFactory _httpClientFactory;
        
        public Scrapper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task Scrap()
        {
            HttpClient client = _httpClientFactory.CreateClient("ScrapperClient");
            
            var request = await client.GetAsync("");
            
            var str = await request.Content.ReadAsStringAsync();

            Regex pattern = new(@"<div class=""tn-tape-item(.*?)"">(.*?)</div>", RegexOptions.Singleline);

            var strings = pattern.Matches(str);



        }
    }
}
