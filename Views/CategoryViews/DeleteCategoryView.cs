using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.CategoryViews
{
    public class DeleteCategoryView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------------");
            Console.WriteLine("Exclusão de Categoria");
            Console.WriteLine("---------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Delete(id);

            Console.ReadKey();
            MenuCategoryView.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Category>();

                var categoryExists = repository.Get(id);
                if (categoryExists is null)
                {
                    Console.WriteLine("Não foi possível localizar a Categoria informada");
                    return;
                }

                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Categoria excluída com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a Categoria.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}