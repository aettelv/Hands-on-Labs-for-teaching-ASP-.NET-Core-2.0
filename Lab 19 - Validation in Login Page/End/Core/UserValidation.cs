using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class UserValidation: NameValidation
    {
        protected const string requiredLength = "UserName length should be between 2 and 7";
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return error(requiredField);
            var s = value.ToString();
            if (s.Length < 2) return error(requiredLength);
            if (s.Length > 7) return error(requiredLength);
            if (!onlyLetters(s)) return error(useOnlyLetters);
            return ValidationResult.Success;
        }
    }
}
