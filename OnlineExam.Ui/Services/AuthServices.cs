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
using OnlineExam.Ui.Options;
namespace OnlineExam.Ui.Services
{
    public class AuthServices
    {
        private readonly RequestServices _requestServices;
        public AuthServices(RequestServices requestServices)
        {
            _requestServices = requestServices;
        }
        public async Task<CommonResponse<SuccessLoginResultDTO>> Login(string phoneNumber, string password)
        {
            var apiUrl = ApiRoutes.Login;
            var content = JsonContent.Create(new
            {
                phoneNumber = phoneNumber,
                password = password
            });
            var options = new RequestOptions()
            {
                HttpMethods = HttpMethod.Post,
                ApiUrl = apiUrl,
                Content = content,
                IncludeCredentials = true,
                RequiresAuth = false
            };
            var result = await _requestServices.SendAsync<SuccessLoginResultDTO>(options);
            return result;
        }
        public async Task<CommonResponse<MyInfoDTO>> GetMyInfo()
        {
            var apiUrl = ApiRoutes.myInfo;
            var options = new RequestOptions()
            {
                HttpMethods = HttpMethod.Get,
                ApiUrl = apiUrl,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            var result = await _requestServices.SendAsync<MyInfoDTO>(options);
            return result;
        }
        public async Task Logout()
        {
            var apiUrl = ApiRoutes.Logout;
            var options = new RequestOptions()
            {
                HttpMethods = HttpMethod.Post,
                ApiUrl = apiUrl,
                IncludeCredentials = true,
            };
            await _requestServices.SendAsync(options);
        }
        public async Task<bool> IsUserLogin()
        {
            var apiUrl = ApiRoutes.myInfo;
            var option = new RequestOptions()
            {
                ApiUrl = apiUrl,
                HttpMethods = HttpMethod.Get,
                IncludeCredentials = true,
                RequiresAuth = true
            };
            var result = await _requestServices.SendAsync<MyInfoDTO>(option);
            if(result.StatusCode==401)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

