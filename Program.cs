using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=balta;User ID=sa;Password=a2t%JH!a@AgaxAG;trustservercertificate=true";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Name}");
                }
            }
        }
    }
}