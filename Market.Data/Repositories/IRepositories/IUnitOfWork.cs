namespace Market.Data.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        public IProductRepository Product { get; }
        int Save();
    }
}
