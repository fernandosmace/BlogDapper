using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        public IEnumerable<T> Get()
            => Database.Connection.GetAll<T>();

        public T Get(int id)
            => Database.Connection.Get<T>(id);

        public void Create(T model)
        {
            Database.Connection.Insert<T>(model);
        }

        public void Update(T model)
        {
            Database.Connection.Update<T>(model);
        }

        public void Delete(T model)
        {
            var id = model.GetType().GetProperty("Id").GetValue(model);

            var item = Database.Connection.Get<T>(id);

            if (item is not null)
                Database.Connection.Delete<T>(model);
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var model = Database.Connection.Get<T>(id);

            if (model is not null)
                Database.Connection.Delete<T>(model);
        }
    }
}