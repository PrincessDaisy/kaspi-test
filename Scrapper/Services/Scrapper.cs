using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Scrapper.Services
{
    public class Scrapper : IScrapper
    {
        public Scrapper(IHttpClientFactory httpClientFactory)
        {

        }
        public Task Scrap()
        {
            
        }
    }
}
