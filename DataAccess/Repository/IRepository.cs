using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Repository
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        public void Add(TEntity entity);
        public void Update(TEntity entity);
        public void Delete(int id);
        public List<TEntity> GetAll();
        public TEntity GetById(int id);
        public void Commit();
    }
}
