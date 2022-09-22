//using Contracts;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Repository
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
//    {
//        private DbContext context;
//        private DbSet<TEntity> dbSet;

//        public Repository(DbContext dbContext)
//        {
//            this.context = dbContext;
//            this.dbSet = context.Set<TEntity>();
//        }

//        public async Task<TEntity> GetById(int id)
//        {
//            return await dbSet.FindAsync(id);
//        }
//        public async Task<IEnumerable<TEntity>> Get()
//        {
//            IQueryable<TEntity> query = dbSet;

//            return query;
//        }
//        public async Task Add(TEntity entity)
//        {
//            await dbSet.AddAsync(entity);
//        }
//        public async Task Update(TEntity entity)
//        {
//            try
//            {
//                dbSet.Attach(entity);
//                context.Entry(entity).State = EntityState.Modified;
//            }
//            catch (Exception ex)
//            {

//                throw;
//            }
//        }
//        //public async Task Delete(TEntity entity)
//        //{
//        //    TEntity entityToDelete = dbSet.Find(id);
//        //    if (context.Entry(entityToDelete).State == EntityState.Detached)
//        //    {
//        //        dbSet.Attach(entityToDelete);
//        //    }
//        //    dbSet.Remove(entityToDelete);
//        //}
//    }
//}
