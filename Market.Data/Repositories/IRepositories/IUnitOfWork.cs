namespace Market.Data.Repositories.IRepositories
{
    public interface IUnitOfWork
    {
        public ICategoryRepository Category { get; }
        int Save();
    }
}
