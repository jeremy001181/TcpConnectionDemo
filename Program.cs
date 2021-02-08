using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApptesthttpclient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var differentDomainUrls = new string[5]{
                "https://www.google.co.uk/",
                "https://uk.yahoo.com/",
                "https://scotch.io/",
                "https://github.com/",
                "https://microsoft.github.io/"
                };

            var sameDomainUrls = Enumerable.Repeat("https://www.google.co.uk/", 200).ToArray();

            //await WhenAll(client, urls);
            await ForEach(client, differentDomainUrls);

            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        private static async Task ForEach(HttpClient client, string[] urls)
        {
            foreach (var url in urls)
            {
                 var _httpRequest = new HttpRequestMessage();
                _httpRequest.Method = new HttpMethod("GET");
                _httpRequest.RequestUri = new System.Uri(url);
                await client.SendAsync(_httpRequest);
            }
        }

        private static async Task WhenAll(HttpClient client, string[] urls)
        {
            var tasks = urls.Select(url =>
            {
                var _httpRequest = new HttpRequestMessage();
                _httpRequest.Method = new HttpMethod("GET");
                _httpRequest.RequestUri = new System.Uri(url);
                return client.SendAsync(_httpRequest);
            });

            await Task.WhenAll(tasks);
        }
    }
}
