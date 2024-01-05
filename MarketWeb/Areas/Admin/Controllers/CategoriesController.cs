
namespace MarketWeb.Areas.Admin.Controllers
{
    [Area(StaticData.AdminArea)]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork _iUnitOfWork;
        public CategoriesController(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public IActionResult Index()
        {
            var categories = _iUnitOfWork.Category.GetAll();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                _iUnitOfWork.Category.Add(model);
                _iUnitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Edit(int Id)
        {
            var category = _iUnitOfWork.Category.Get(c => c.Id == Id);
            return View(category);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _iUnitOfWork.Category.Update(model);
                _iUnitOfWork.Save();
                TempData["success"] = "Category Edited Successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }




        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            if (Id != null && Id != 0)
            {
                var category = _iUnitOfWork.Category.Get(c => c.Id == Id);
                _iUnitOfWork.Category.Remove(category);

            }
            return _iUnitOfWork.Save() > 0 ? Ok() : BadRequest();
        }

    }
}
