namespace Market.Data.Repositories.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);

    }
}
