using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class Program
    {
        private const string APP_PATH = "http://localhost:44338";


        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                var resp = client.GetAsync(APP_PATH + "/post").Result;
                Console.WriteLine(resp.ToString());
            }
        }
    }
}
