using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Market.Utility.Custom_Attr
{
    public class MaxImgSizeAttribute : ValidationAttribute
    {
        private readonly int _maxImgSize;
        public MaxImgSizeAttribute(int maxImgSize)
        {
            _maxImgSize = maxImgSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null)
            {
                if (file.Length > _maxImgSize)
                {
                    return new ValidationResult($"The Maximum Image Size Is {_maxImgSize} Byte ");
                }
            }
            return ValidationResult.Success;
        }
    }
}
