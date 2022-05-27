using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.RoleViews
{
    public class ListRoleView
    {

        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------");
            Console.WriteLine("Lista de Perfis");
            Console.WriteLine("--------------");

            List();

            Console.ReadKey();
            MenuRoleView.Load();
        }

        private static void List()
        {
            var repository = new Repository<Role>();
            var roles = repository.Get();
            foreach (var item in roles)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}