using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Market.Utility.Custom_Attr
{
    public class ImgAllowedExtenssions : ValidationAttribute
    {
        private readonly string _allowedExtensions;

        public ImgAllowedExtenssions(string allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                var filePath = Path.GetExtension(file.FileName);
                var isAllowed = _allowedExtensions.Split(",").Contains(filePath, StringComparer.OrdinalIgnoreCase);

                if (!isAllowed)
                {
                    return new ValidationResult($"Only {_allowedExtensions} Is Allowed");
                }
            }
            return ValidationResult.Success;

        }
    }
}
