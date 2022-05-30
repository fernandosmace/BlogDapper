using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.CategoryViews
{
    public class UpdateCategoryView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------------------");
            Console.WriteLine("Atualização de Categoria");
            Console.WriteLine("-----------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Category
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuCategoryView.Load();
        }

        private static void Update(Category category)
        {
            try
            {
                var repository = new Repository<Category>();

                var categoryExists = repository.Get(category.Id);
                if (categoryExists is null)
                {
                    Console.WriteLine("Não foi possível localizar a Categoria informada");
                    return;
                }

                repository.Update(category);

                Console.WriteLine();
                Console.WriteLine("Categoria atualizada com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a Categoria.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}