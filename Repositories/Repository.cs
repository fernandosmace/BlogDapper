using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly SqlConnection _connection;

        public Repository(SqlConnection connection)
            => _connection = connection;

        public IEnumerable<T> Get()
            => _connection.GetAll<T>();

        public T Get(int id)
            => _connection.Get<T>(id);

        public void Create(T model)
        {
            _connection.Insert<T>(model);
        }

        public void Update(T model)
        {
            _connection.Update<T>(model);
        }

        public void Delete(T model)
        {
            var id = model.GetType().GetProperty("Id").GetValue(model);

            var item = _connection.Get<T>(id);

            if (item is not null)
                _connection.Delete<T>(model);
        }

        public void Delete(int id)
        {
            if (id == 0)
                return;

            var model = _connection.Get<T>(id);

            if(model is not null)
                _connection.Delete<T>(model);
        }
    }
}