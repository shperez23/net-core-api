using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class EFCoreBlogRepository: IDisposable
    {
         
        readonly BlogContext context;
        readonly bool IsUnitOfWork;
        public EFCoreBlogRepository(BlogContext context, bool isUnitOfWork = false)
        {
            this.context = context;
            this.IsUnitOfWork = isUnitOfWork;

        }


        public virtual T Create<T>(T entity) where T : class
        {
            T NewEntity = context.Add(entity).Entity;
            Save();
            return NewEntity;
        }


        public virtual T RetrieveByID<T>(params object[] keyValues) where T : class
        {
            return context.Find<T>(keyValues);
        }

        public virtual bool Update<T>(T entity) where T : class
        {
            context.Update(entity);
            return Save();
        }



        public virtual bool Delete<T>(T entity) where T : class
        {
            context.Remove(entity);
            return Save();
        }


        public virtual List<T> GetAll<T>() where T : class
        {
            return context.Set<T>().ToList();
        }


        public void Dispose()
        {
            context.Dispose();
        }


        public virtual int SaveChanges()
        {
            var Result = 0;
            if (context != null)
            {
                try
                {
                    Result = context.SaveChanges();
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }


            return Result;
        }


        private bool Save()
        {
            int changes = 0;
            if (!IsUnitOfWork)
            {
                changes = SaveChanges();
            }
            return changes == 1;

        }

        public virtual void HandleException(Exception ex)
        {
        }

    }
}
