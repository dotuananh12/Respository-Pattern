using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RespositoryBase<T> : IRespositoryBase<T> where T : class
    {
        AppDbContext _RespositoryContext { get; set; }

        public RespositoryBase(AppDbContext RespositoryContext)
        {
            this._RespositoryContext = RespositoryContext;
        }
        public void Create(T entity)
        {
            this._RespositoryContext.Set<T>().Add(entity);
            this._RespositoryContext.SaveChanges();
        }
        public void Update(T entity)
        {
            this._RespositoryContext.Set<T>().Update(entity);
            this._RespositoryContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            this._RespositoryContext.Set<T>().Remove(entity);
            this._RespositoryContext.SaveChanges();
        }

        public IQueryable<T> FindAll()
        {
            return this._RespositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindbyCondition(Expression<Func<T, bool>> expression)
        {
            return this._RespositoryContext.Set<T>().Where(expression).AsNoTracking();
        }       
    }
}
