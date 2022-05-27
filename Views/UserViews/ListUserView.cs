using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Views.UserViews;

namespace Blog.Views.UserViews
{
    public class ListUserView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------");
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("-------------");

            List();

            Console.ReadKey();
            MenuUserView.Load();
        }

        private static void List()
        {
            var repository = new Repository<User>();
            var tags = repository.Get();
            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}