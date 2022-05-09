using System;
using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=a2t%JH!a@AgaxAG;trustservercertificate=true";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();

            //ReadUsers(connection);
            //ReadUser(connection, {id});
            //CreateUser(connection);
            //UpdateUser(connection);
            //DeleteUser(connection, {id});
            //DeleteUserById(connection, {id});

            //ReadRoles(connection);
            //ReadRole(connection, {id});
            //CreateRole(connection);
            //UpdateRole(connection);
            //DeleteRole(connection, {id});
            //DeleteRoleById(connection, {id});

            //ReadTags(connection);
            //ReadTag(connection, {id});
            //CreateTag(connection);
            //UpdateTag(connection);
            //DeleteTag(connection, {id});
            //DeleteTagById(connection, {id});

            //ReadCategories(connection);
            //ReadCategory(connection, {id});
            //CreateCategory(connection);
            //UpdateCategory(connection);
            //DeleteCategory(connection, {id});
            //DeleteCategoryById(connection, {id});

            connection.Close();
        }


        //### Users

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
            
            
            Console.WriteLine("-----");
        }

        public static void ReadUser(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(id);

            Console.WriteLine($"{user.Name}");
            Console.WriteLine("-----");
        }

        public static void CreateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);

            var user = new User(){
                Name = "Fernando",
                Email = "teste@teste2abfhsdasc.com.br",
                PasswordHash = "HASH",
                Bio = "Teste de usuário",
                Image ="http://image.png",
                Slug = "fernando-aasasbfjhfc"
            };

            repository.Create(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);

            var user = new User(){
                Id = 20,
                Name = "Fernando Soares Macedo",
                Email = "fernando@teste.com.br",
                PasswordHash = "HASH",
                Bio = "Teste de usuário",
                Image ="http://image.png",
                Slug = "fernando-soares"
            };

            repository.Update(user);
        }

        public static void DeleteUser(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);

            var user = repository.Get(id);

            if(user is null)
                return;

            repository.Delete(user);
        }

        public static void DeleteUserById(SqlConnection connection, int id)
        {
            var repository = new Repository<User>(connection);

            repository.Delete(id);
        }

        //### Roles

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
        }

        public static void ReadRole(SqlConnection connection, int id)
        {
            var repository = new Repository<Role>(connection);
            var user = repository.Get(id);

            Console.WriteLine($"{user.Name}");
            Console.WriteLine("-----");
        }

        public static void CreateRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);

            var role = new Role(){
                Name = "Super Adm",
                Slug = "super-adm"
            };

            repository.Create(role);
        }

        public static void UpdateRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);

            var role = new Role(){
                Id = 1,
                Name = "Super Admin",
                Slug = "super-admin"
            };

            repository.Update(role);
        }

        public static void DeleteRole(SqlConnection connection, int id)
        {
            var repository = new Repository<Role>(connection);

            var user = repository.Get(id);

            if(user is null)
                return;

            repository.Delete(user);
        }

        public static void DeleteRoleById(SqlConnection connection, int id)
        {
            var repository = new Repository<Role>(connection);

            repository.Delete(id);
        }

        //### Tags

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
        }

        public static void ReadTag(SqlConnection connection, int id)
        {
            var repository = new Repository<Tag>(connection);
            var user = repository.Get(id);

            Console.WriteLine($"{user.Name}");
            Console.WriteLine("-----");
        }

        public static void CreateTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);

            var tag = new Tag(){
                Name = "python",
                Slug = "python"
            };

            repository.Create(tag);
        }

        public static void UpdateTag(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);

            var tag = new Tag(){
                Id = 2,
                Name = "python3",
                Slug = "python3"
            };

            repository.Update(tag);
        }

        public static void DeleteTag(SqlConnection connection, int id)
        {
            var repository = new Repository<Tag>(connection);

            var user = repository.Get(id);

            if(user is null)
                return;

            repository.Delete(user);
        }

        public static void DeleteTagById(SqlConnection connection, int id)
        {
            var repository = new Repository<Tag>(connection);

            repository.Delete(id);
        }

        //### Categories

        public static void ReadCategories(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
        }

        public static void ReadCategory(SqlConnection connection, int id)
        {
            var repository = new Repository<Category>(connection);
            var user = repository.Get(id);

            Console.WriteLine($"{user.Name}");
            Console.WriteLine("-----");
        }

        public static void CreateCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);

            var category = new Category(){
                Name = "web",
                Slug = "web"
            };

            repository.Create(category);
        }

        public static void UpdateCategory(SqlConnection connection)
        {
            var repository = new Repository<Category>(connection);

            var category = new Category(){
                Id = 2,
                Name = "web-development",
                Slug = "web-development"
            };

            repository.Update(category);
        }

        public static void DeleteCategory(SqlConnection connection, int id)
        {
            var repository = new Repository<Category>(connection);

            var user = repository.Get(id);

            if(user is null)
                return;

            repository.Delete(user);
        }

        public static void DeleteCategoryById(SqlConnection connection, int id)
        {
            var repository = new Repository<Category>(connection);

            repository.Delete(id);
        }

    }
}