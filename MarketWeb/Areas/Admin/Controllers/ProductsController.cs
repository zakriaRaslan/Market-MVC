using Market.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MarketWeb.Areas.Admin.Controllers
{
    [Area(StaticData.AdminArea)]
    public class ProductsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string rootPath;
        public ProductsController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            rootPath = _webHostEnvironment.WebRootPath;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll("Category");
            return View(products);
        }

        public IActionResult Upsert(int? Id)
        {
            ProductViewModel productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll()
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }),
                Product = new Product() { Title = "", Description = "" }
            };

            if (Id == null)
            {
                return View(productVM);
            }
            else
            {
                var dbProduct = _unitOfWork.Product.Get(x => x.Id == Id);
                productVM.Product = dbProduct;
                return View(productVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductViewModel ProductVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {


                if (file != null)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var productImagePath = Path.Combine(rootPath, StaticData.ProductImagePath);
                    if (!string.IsNullOrEmpty(ProductVM.Product.Image))
                    {
                        var oldImagePath = Path.Combine(rootPath, ProductVM.Product.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productImagePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    ProductVM.Product.Image = StaticData.ProductImageDataBase + fileName;
                }
                if (ProductVM.Product.Id == 0)
                {
                    _unitOfWork.Product.Add(ProductVM.Product);
                    TempData["Success"] = "Product Created Successfully";

                }
                else
                {

                    _unitOfWork.Product.Update(ProductVM.Product);
                    TempData["Success"] = "Product Updated Successfully";
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }



            ProductVM.CategoryList = _unitOfWork.Category.GetAll()
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name });
            return View(ProductVM);



        }

        #region Api Calls

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _unitOfWork.Product.GetAll("Category");
            return Json(new { data = products });
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var productToDelete = _unitOfWork.Product.Get(x => x.Id == Id);
            if (productToDelete == null)
            {
                return Json(new { success = false, message = "Something Went Wrong When Deleting" });
            }
            if (productToDelete.Image != null)
            {
                var oldImagePath = Path.Combine(rootPath, productToDelete.Image.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            _unitOfWork.Product.Remove(productToDelete);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfully" });
        }

        #endregion

    }

}
