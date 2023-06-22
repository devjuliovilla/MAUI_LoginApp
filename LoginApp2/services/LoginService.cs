using LoginApp2.models;
using System.Net.Http.Json;

namespace LoginApp2.services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient httpClient;

        public LoginService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public string HelloWorld(LoginRequest request)
        {
            return $"Hello {request.Email}";
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync(
                "https://test-api.ithub-webhost.net/Login",
                    //"https://localhost:7180/Login", 
                    request);
                response.EnsureSuccessStatusCode();
                LoginResponse result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
