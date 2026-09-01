using Microsoft.AspNetCore.Identity;

namespace OnlineExam.Identity.ErrorDescribers
{

    public class ErrorToFarsi : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName) => new IdentityError
        {
            Code = nameof(DuplicateUserName),
            Description = "نام کاربری تکراری است.",
        };
        public override IdentityError PasswordRequiresDigit() => new IdentityError
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "رمز عبور باید حداقل دارای یک عدد باشد"
        };
        public override IdentityError PasswordRequiresLower() => new IdentityError
        {
            Code = nameof(PasswordRequiresLower),
            Description = "رمز عبور باید حداقل یک حرف کوچک داشته باشد.",
        };
        public override IdentityError PasswordRequiresUpper() => new IdentityError
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "رمز عبور باید حداقل یک حرف بزرگ داشته باشد."
        };
        public override IdentityError PasswordTooShort(int length) => new IdentityError
        {
            Code = nameof(PasswordTooShort),
            Description = $"رمز عبور باید حداقل {length} کاراکتر باشد."
        };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = "رمز عبور باید حداقل یک علامت داشته باشد."
        };

        public override IdentityError InvalidEmail(string? email) => new IdentityError
        {
            Code = nameof(InvalidEmail),
            Description = $"ایمیل {email} معتبر نیست"
        };
        public override IdentityError DuplicateEmail(string email) => new IdentityError
        {
            Code = nameof(DuplicateEmail),
            Description = $"ایمیل {email} تکراری است."
        };

    }

}
