using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new() where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using=>IDisposable pattern implementation of C#
            //using ile NortwindContext işi bitince bellekten atılacak//daha perfomanslo
            using (TContext context = new TContext())  //c# a özel bir yapı 
            {
                var addedEntity = context.Entry(entity);//referansı yakalama 
                addedEntity.State = EntityState.Added; //o aslında eklenecek bir nesne
                context.SaveChanges(); //ve şimdi ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())  //c# a özel bir yapı 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                     ? context.Set<TEntity>().ToList() //DbSetteki producta yerleş//select*from Products yapıyor
                     : context.Set<TEntity>().Where(filter).ToList();  //lamda varsa onu where ile filtere getir
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())  //c# a özel bir yapı 
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
