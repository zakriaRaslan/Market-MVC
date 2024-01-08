using Market.Data.Data;
namespace Market.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly string _ImagePath;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Product obj)
        {
            var dbProduct = _context.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (dbProduct != null)
            {
                dbProduct.Title = obj.Title;
                dbProduct.Description = obj.Description;
                dbProduct.Price = obj.Price;
                dbProduct.CategoryId = obj.CategoryId;
                if (obj.Image != null)
                {
                    dbProduct.Image = obj.Image;
                }
            }
        }


    }
}
