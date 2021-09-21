using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IBlogRepository : IDisposable
    {
        T Create<T>(T entity) where T : class;
        T RetrieveByID<T>(params object[] keyValues) where T : class;

        bool Update<T>(T entity) where T : class;
        bool Delete<T>(T entity) where T : class;
        List<T> GetAll<T>() where T : class; 
        int SaveChanges();

    }
}
