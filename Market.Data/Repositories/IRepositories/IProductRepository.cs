namespace Market.Data.Repositories.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
