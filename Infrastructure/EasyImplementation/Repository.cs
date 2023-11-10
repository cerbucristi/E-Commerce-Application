using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EasyImplementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyDbContext _context;
        private DbSet<TEntity> _entities;

        public Repository(MyDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public TEntity FindById(object id)
        {
            return _entities.Find(id)!;
        }
    }
}