using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repository
{
    public class EfRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
    {
        private OnlineCourseDbContext _context;
        public EfRepositoryBase(OnlineCourseDbContext context) => _context = context;

        public void Add(TEntity entity) => _context.Set<TEntity>().Add(entity);
        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
        public void Delete(int id)
        {
            var deletedEntity = _context.Set<TEntity>().Find(id);
            _context.Remove(deletedEntity);
        }
        public List<TEntity> GetAll() => _context.Set<TEntity>().ToList();
        public TEntity GetById(int entityId) => _context.Set<TEntity>().Find(entityId);
        public void Commit() => _context.SaveChanges();
    }
}
