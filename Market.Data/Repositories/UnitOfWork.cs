using Market.Data.Data;

namespace Market.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
