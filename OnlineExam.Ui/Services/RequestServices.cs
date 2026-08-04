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
            try
            {
                HttpRequestMessage request = new HttpRequestMessage(requestOptions.HttpMethods, requestOptions.ApiUrl);
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
                if (requestOptions.Content != null)
                {
                    request.Content = requestOptions.Content;
                }
                if (requestOptions.IncludeCredentials)
                {
                    request.SetBrowserRequestCredentials(BrowserRequestCredentials.Include);
                }

                var response = await _httpClient.SendAsync(request);
                //fill response
                result.StatusCode = (int)response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    if (response.Content != null && requestOptions.GetData != false)
                    {
                        result.Data = typeof(TResult) == typeof(string) ? (TResult)(object)await response.Content.ReadAsStringAsync() : await response.Content.ReadFromJsonAsync<TResult>();
                    }
                    result.IsSuccess = true;
                }
                //response has error
                else
                {
                    if (request.Content != null)
                    {
                        result.Errors = new List<string>();
                        var errorResponse = await response.Content.ReadFromJsonAsync<CommonResponse<TResult>>();
                        result.Errors = errorResponse?.Errors ?? new List<string>();
                    }
                    result.IsSuccess = false;
                }
                return result;
            }
            catch
            {
                var exception = new CommonResponse<TResult>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                };
                exception.Errors.Add("خطایی سمت سرور رخ داد.");
                return exception;
            }

        }
        public async Task<int> SendAsync(RequestOptions requestOptions)
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
                return (int)response.StatusCode;
            }
            else
            {
                return (int)response.StatusCode;
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
