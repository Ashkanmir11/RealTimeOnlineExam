using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineExam.Ui.DTO.Account
{
    public class RegisterDTO
    {
        [MaxLength(150,ErrorMessage ="نام نباید بیشتر از 150 کاراکتر باشد.")]
        public string? FirstName { get; set; }
        [MaxLength(150, ErrorMessage = "نام خانوادگی نباید بیشتر از 150 کاراکتر باشد.")]
        public string? LastName { get; set; }
        [EmailAddress(ErrorMessage ="ادرس ایمیل معتبر نیست.")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "رمز عبور با تکرار رمز عبور برابر نیست.")]
        public string? ConfirmPassword { get; set; }
        [MaxLength(11,ErrorMessage ="شماره موبایل معتبر نیست.")]
        [MinLength(11, ErrorMessage = "شماره موبایل معتبر نیست.")]
        public string? PhoneNumber { get; set; }

    }
}
