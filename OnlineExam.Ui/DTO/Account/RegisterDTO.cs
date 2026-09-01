using System.ComponentModel.DataAnnotations;

namespace OnlineExam.Ui.DTO.Account
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "نام نباید خالی باشد.")]
        [MaxLength(150, ErrorMessage = "نام نباید بیشتر از 150 کاراکتر باشد.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "نام خانوادگی نباید خالی باشد.")]
        [MaxLength(150, ErrorMessage = "نام خانوادگی نباید بیشتر از 150 کاراکتر باشد.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "ایمیل نباید خالی باشد.")]
        [EmailAddress(ErrorMessage = "ادرس ایمیل معتبر نیست.")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "رمز عبور نباید خالی باشد.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "رمز عبور با تکرار رمز عبور برابر نیست.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage = "شماره تلفن نباید خالی باشد.")]
        [MaxLength(11, ErrorMessage = "شماره موبایل معتبر نیست.")]
        [MinLength(11, ErrorMessage = "شماره موبایل معتبر نیست.")]
        public string? PhoneNumber { get; set; }

    }
}
