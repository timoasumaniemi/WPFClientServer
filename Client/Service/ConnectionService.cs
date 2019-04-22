using System;
using System.ComponentModel.Composition;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service
{
    [Export(typeof(IConnectionService))]
    public class ConnectionService : IConnectionService
    {
        private HttpClient _client;

        public async Task<string> GetString()
        {
            _client = new HttpClient();

            _client.BaseAddress = new Uri("http://localhost");
            _client.DefaultRequestHeaders.Accept.Clear();

            var response = await _client.GetAsync("http://localhost/api/message");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> SendMessage(string message)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();

            // adding '=' characted as first seems to solve issue where server didn't receive
            // the message at all. TODO: Have to fiqure out more cleaner way.
            var messageToSend = "=" + message;

            var response = await _client.PostAsync(
                "http://localhost/sendmessage", 
                new StringContent(messageToSend, Encoding.UTF8, "application/x-www-form-urlencoded"));
           
            response.EnsureSuccessStatusCode();

            //TODO: Add Status code checking for OK or NOK responses
            return response.Content.ReadAsStringAsync().Result;
        }
    }
}