using DataAccess.Concrete;
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
        public EfRepositoryBase() { }
        public EfRepositoryBase(OnlineCourseDbContext context) => _context = context;
        public void Add(TEntity entity) => _context.Add(entity);
        public void Update(TEntity entity) => _context.Update(entity);
        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            _context.Remove(entity);
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int entityId)
        {
            return _context.Set<TEntity>().Find(entityId);
        }
        public void Commit() => _context.SaveChanges();
    }
}
