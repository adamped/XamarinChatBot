using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChatBot.Framework
{
    public class HttpClient
    {
        System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();

        public async Task<HttpResponse> Get(HttpRequest request)
        {
            var response = new HttpResponse();

            var result = await _client.GetAsync(request.Url);

            response.IsSuccess = result.IsSuccessStatusCode;

            if (response.IsSuccess)
                response.Data = await result.Content.ReadAsStringAsync();

            return response;
        }

        public async Task<HttpResponse> Post(HttpRequest request)
        {
            try
            {
                var response = new HttpResponse();

                var requestMessage = new HttpRequestMessage()
                {
                    Content = new StringContent(request.Data, System.Text.Encoding.UTF8, "application/json"),
                    RequestUri = new Uri(request.Url),
                    Method = HttpMethod.Post
                };

                var result = await _client.SendAsync(requestMessage);

                response.IsSuccess = result.IsSuccessStatusCode;

                if (response.IsSuccess)
                    response.Data = await result.Content.ReadAsStringAsync();

                return response;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
