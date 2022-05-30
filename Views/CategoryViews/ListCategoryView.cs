using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.CategoryViews
{
    public class ListCategoryView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Lista de Categorias");
            Console.WriteLine("-------------------");

            List();

            Console.ReadKey();
            MenuCategoryView.Load();
        }

        private static void List()
        {
            var repository = new Repository<Category>();
            var categories = repository.Get();
            foreach (var item in categories)
            {
                Console.WriteLine($"{item.Id} - {item.Name} ({item.Slug})");
            }
        }
    }
}