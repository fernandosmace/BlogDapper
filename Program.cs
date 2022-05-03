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

            ReadUsers(connection);
            DeleteUser(connection, 1);
            //CreateUser(connection);
            //ReadUsers(connection);
            //UpdateUser(connection);
            //ReadUsers(connection);
            //DeleteUser(connection, 3);
            //ReadUsers(connection);

            //ReadRoles(connection);
            //ReadTags(connection);

            connection.Close();

        }

        public static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Get(2);

            Console.WriteLine("-----");
            Console.WriteLine($"{user.Name}");
            Console.WriteLine("-----");
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();

            Console.WriteLine("-----");

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
            
            
            Console.WriteLine("-----");
        }

        public static void CreateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);

            var user = new User(){
                Name = "Fernando",
                Email = "teste@teste.com.br",
                PasswordHash = "HASH",
                Bio = "Teste de usuário",
                Image ="http://image.png",
                Slug = "fernando-macedo"
            };

            repository.Create(user);
        }

        public static void UpdateUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);

            var user = new User(){
                Id = 3,
                Name = "Fernando Macedo",
                Email = "teste@teste.com.br",
                PasswordHash = "HASH",
                Bio = "Teste de usuário",
                Image ="http://image.png",
                Slug = "fernando-macedo"
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

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
        }

        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();

            foreach (var item in items)
                Console.WriteLine($"{item.Name}");
        }

    }
}