using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson15
{
    public class UserClient
    {
        private readonly HttpClient httpClient;

        public UserClient()
        {
            httpClient = new HttpClient();
        }

        public async Task GetAsync()
        {
            Console.WriteLine(await httpClient.GetStringAsync("http://localhost:5000/user"));
        }

        public async Task AddAsync(string name)
        {
            Console.WriteLine("Add requested");
            var task = httpClient.GetStringAsync($"http://localhost:5000/user/add?username={name}");
            Console.WriteLine("Add processing...");
            var result = await task;
            Console.WriteLine("Add processed!");
            Console.WriteLine(result);
        }
    }
}
