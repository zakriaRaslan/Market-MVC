using System.Diagnostics;

namespace MarketWeb.Areas.Customer.Controllers
{
    [Area(StaticData.CustomerArea)]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = _unitOfWork.Product.GetAll("Category");
            return View(products);
        }

        public IActionResult ProdDetails(int Id)
        {
            var product = _unitOfWork.Product.Get(x => x.Id == Id, "Category");
            if (product != null)
            {
                return View(product);
            }
            TempData["error"] = "Sorry Something Went Wrong";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
