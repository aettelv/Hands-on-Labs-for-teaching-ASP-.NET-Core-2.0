using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Core
{
    public class NameValidation : ValidationAttribute
    {
        protected const string requiredField = "Required field!";
        protected const string lenghtIsToBig = "Length should be less than 20 characters!!";
        protected const string useOnlyLetters = "Use only letters!";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return error(requiredField);
            var s = value.ToString();
            if (s.Length > 20) return error(lenghtIsToBig);
            if (!onlyLetters(s)) return error(useOnlyLetters);
            return ValidationResult.Success;
        }
        protected static bool onlyLetters(string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (string.IsNullOrEmpty(s.Trim())) return false;
            return s.All(char.IsLetter);
        }

        protected static ValidationResult error(string s)
        {
            return new ValidationResult(s);
        }
    }
}
