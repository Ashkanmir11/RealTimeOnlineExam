using OnlineExam.Application.Contracts.AIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenAI.Responses;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI;
using static System.Formats.Asn1.AsnWriter;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
namespace OnlineExam.Application.Serviecs
{
    public class AiServices : IAiServices
    {
        private readonly IConfiguration _configuration;
        public AiServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<decimal> GetScoreAsync(string StudentText, string CorrectText, decimal Score)
        {
            try
            {
                var apiKey = _configuration["AiKey"];
                if (string.IsNullOrWhiteSpace(apiKey))
                    throw new InvalidOperationException("AiKey is missing.");

                using var httpClient = new HttpClient();

                httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", apiKey);

                var requestData = new
                {
                    model = "gapgpt-qwen-3.6",
                    messages = new[]
                    {
                    new { role = "system", content = "You are a scoring assistant. Return only one decimal number." },
                    new
                    {
                        role = "user",
                        content = $"این متن صحیح: {CorrectText}\nاین متن دانش آموز: {StudentText}\n" +
                                  $"بر اساس متن صحیح و متن دانش آموز، یک نمره بین 0 و {Score} بده. " +
                                  "فقط یک عدد decimal برگردان."
                    }
                }
                };

                var jsonContent = JsonConvert.SerializeObject(requestData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var apiUrl = "https://api.gapgpt.app/v1/chat/completions";
                var response = await httpClient.PostAsync(apiUrl, content);

                var responseBody = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                    throw new Exception($"API error: {response.StatusCode} - {responseBody}");

                var json = JObject.Parse(responseBody);
                string resultText = json["choices"]?[0]?["message"]?["content"]?.ToString();
                if (decimal.TryParse(resultText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal scoreResult))
                {
                    return scoreResult;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
