using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.PostViews
{
    public class DeletePostView
    {
        public static void Load()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Excluir Post");
            Console.WriteLine("------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Delete(id);

            Console.ReadKey();
            MenuPostView.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Post>();

                var postExists = repository.Get(id);
                if (postExists is null)
                {
                    Console.WriteLine("Não foi possível excluir o Post informado");
                    return;
                }

                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Post excluído com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível excluir o Post.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}