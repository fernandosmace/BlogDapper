using System;
using Blog.Views;
using Blog.Views.TagViews;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();


            var CONNECTION_STRING = config["Database:ConnectionString"];

            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            StartView.Load();

            Console.ReadKey();

            Database.Connection.Close();
        }
    }
}