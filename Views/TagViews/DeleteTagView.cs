using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.TagViews
{
    public class DeleteTagView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("Exclusão de Tag");
            Console.WriteLine("------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Delete(id);

            Console.ReadKey();
            MenuTagView.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>();

                var tagExists = repository.Get(id);
                if (tagExists is null)
                {
                    Console.WriteLine("Não foi possível localizar a Tag informada");
                    return;
                }

                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Tag excluída com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}