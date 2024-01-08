using Market.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Market.Models.ViewModels
{
    public class ProductViewModel
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        //[ImgAllowedExtenssions(StaticData.AllowedImgExtensions),
        //   MaxImgSize(FileSettings.MaxImgSizeInByte)]
        public IFormFile? ImageFile { get; set; }

    }
}
