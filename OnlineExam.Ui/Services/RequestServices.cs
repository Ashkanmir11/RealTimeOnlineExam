using Microsoft.AspNetCore.Components.WebAssembly.Http;
using OnlineExam.Ui.DTO.Account;
using OnlineExam.Ui.EndPoints;
using OnlineExam.Ui.Options;
using OnlineExam.Ui.Response;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;

namespace OnlineExam.Ui.Services
{
    public class RequestServices
    {
        private readonly HttpClient _httpClient;
        public RequestServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommonResponse<TResult>> SendAsync<TResult>(RequestOptions requestOptions)
        {

            var result = new CommonResponse<TResult>();
            if (requestOptions.RequiresAuth)
            {
                if (await refreshToken() == 401)
                {
                    result.IsSuccess = false;
                    result.Errors = new()
                    {
                        "لطفا وارد شوید."
                    };
                    result.StatusCode = 401;
                    return result;
                }
            }
            HttpRequestMessage request = new HttpRequestMessage(requestOptions.HttpMethods, requestOptions.ApiUrl);
            if (requestOptions.Content != null)
            {
                request.Content = requestOptions.Content;
            }
            if (requestOptions.IncludeCredentials)
            {
                request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            }

            var response = await _httpClient.SendAsync(request);
            result.StatusCode = (int)response.StatusCode;
            if (!response.IsSuccessStatusCode)
            {
                result.Errors = new List<string>();
                var errorResponse = await response.Content.ReadFromJsonAsync<CommonResponse<TResult>>();
                result.Errors = errorResponse?.Errors ?? new List<string>();
                result.IsSuccess = false;
            }
            else
            {
                result.IsSuccess = true;
                if (typeof(TResult) == typeof(string))
                {
                    result.Data = (TResult)(object)await response.Content.ReadAsStringAsync();
                }
                else
                {
                    result.Data = await response.Content.ReadFromJsonAsync<TResult>();
                }
            }
            return result;


        }
        public async Task<bool> SendAsync(RequestOptions requestOptions)
        {
            HttpRequestMessage request = new HttpRequestMessage(requestOptions.HttpMethods, requestOptions.ApiUrl);
            if (requestOptions.Content != null)
            {
                request.Content = requestOptions.Content;
            }
            if (requestOptions.IncludeCredentials)
            {
                request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            }
            var response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async Task<int> refreshToken()
        {

            var apiUrl = ApiRoutes.RefreshToken;
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
            request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
            var response = await _httpClient.SendAsync(request);
            return (int)response.StatusCode;


        }
    }
}
