using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.CategoryViews
{
    public class CreateCategoryView
    {
        public static void Load()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Nova Categoria");
            Console.WriteLine("--------------");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Category
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryView.Load();
        }

        private static void Create(Category category)
        {
            try
            {
                var repository = new Repository<Category>();
                repository.Create(category);

                Console.WriteLine();
                Console.WriteLine("Categoria inserida com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir a Categoria.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}