namespace Emerging.Account.WebApi.Services.Auth0
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    public class Auth0Service
    {
        private readonly IHttpClientFactory http;
        private readonly Auth0Config config;

        public Auth0Service(
            IHttpClientFactory http,
            Auth0Config config)
        {
            this.http = http;
            this.config = config;
        }

        public async Task<string> SignUpAndGetId(string email, string password)
        {
            var client = http.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Post, config.SignupUrl);
            var body = new
            {
                client_id = config.ClientId,
                connection = config.Connection,
                email = email,
                password = password
            };

            request.Content = new StringContent(JObject.FromObject(body).ToString(), Encoding.UTF8, "application/json");

            var response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();
                var exception = new Exception(message);
                throw new Exception("An exception ocurred when sending user POST to Auth0.", exception);
            }

            var auth0User = await response.Content.ReadAsAsync<Auth0SignupResponse>();

            return auth0User._id;
        }
    }
}
