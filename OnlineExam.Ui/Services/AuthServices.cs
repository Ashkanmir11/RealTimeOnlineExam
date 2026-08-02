using OnlineExam.Ui.Response;
using OnlineExam.Ui.EndPoints;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using OnlineExam.Ui.DTO.Account;
using System.Reflection;
using System.Collections;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
namespace OnlineExam.Ui.Services
{
    public class AuthServices
    {
        private readonly HttpClient _httpClient;
        public AuthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CommonResponse<SuccessLoginResultDTO>> Login(string phoneNumber, string password)
        {
            var result = new CommonResponse<SuccessLoginResultDTO>();
            result.Errors = new List<string>();
            var apiUrl = ApiRoutes.Login;
            var request = new HttpRequestMessage(HttpMethod.Post, apiUrl);

            request.Content = JsonContent.Create(new
            {
                phoneNumber = phoneNumber,
                password =password
            });
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            var response = await _httpClient.SendAsync(request);
            result.StatusCode = (int)response.StatusCode;
            if (!response.IsSuccessStatusCode)
            {
                result.IsSuccess = false;
                var erroes = await response.Content.ReadFromJsonAsync<CommonResponse<SuccessLoginResultDTO>>();
                result.Errors.AddRange(erroes.Errors.ToList());
                return result;
            }

            result.IsSuccess = true;
            result.Data = await response.Content.ReadFromJsonAsync<SuccessLoginResultDTO>();
            return result;
        }
    }
}

