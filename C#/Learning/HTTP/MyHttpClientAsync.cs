using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Learning.HTTP
{
    public class MyHttpClientAsync
    {
        public async void Process()
        {
            string cep = "04101300";
            string url = $"http://viacep.com.br/ws/{cep}/json/";

            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                Console.WriteLine(json);
            }
        }
    }
}
