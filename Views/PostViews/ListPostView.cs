using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.PostViews
{
    public class ListPostView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("--------------");
            Console.WriteLine("Lista de Posts");
            Console.WriteLine("--------------");

            List();

            Console.ReadKey();
            MenuPostView.Load();
        }

        private static void List()
        {
            var repository = new PostRepository();
            var categories = repository.Get();
            foreach (var item in categories)
            {
                Console.WriteLine($"Id: {item.Id} | Título: {item.Title} | Resumo: ({item.Summary})");
                Console.WriteLine($"Categoria: {item.Category.Name} | Autor: {item.Author.Name}");


                Console.WriteLine();
                Console.WriteLine("--");
                Console.WriteLine();
            }
        }
    }
}