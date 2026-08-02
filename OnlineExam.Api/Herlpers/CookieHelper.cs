namespace OnlineExam.Api.Herlpers
{
    public class CookieHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetRefreshToken(string refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.Now.AddDays(10),

            };

            if (_httpContextAccessor.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
            }
        }

        public void SetAccessToken(string accessToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = false,
                Secure = true,
                SameSite = SameSiteMode.None,
                Expires = DateTimeOffset.Now.AddMinutes(30)
            };

            if (_httpContextAccessor.HttpContext != null)
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Append("accessToken", accessToken, cookieOptions);
            }

        }
        public string GetCookieValue(string cookieName)
        {
            _httpContextAccessor.HttpContext.Request.Cookies.TryGetValue(cookieName, out var result);
            return result;
        }
        public void DeleteCookie(HttpResponse httpResponse,string cookieName)
        {

            httpResponse.Cookies.Delete(cookieName);
            
            // Specify the same path, domain, and Secure/HttpOnly flags as when the cookie was created
            
        }
    }
}
