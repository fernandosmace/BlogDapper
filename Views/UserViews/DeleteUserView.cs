using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.UserViews
{
    public class DeleteUserView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Exclusão de Usuário");
            Console.WriteLine("-------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Delete(id);

            Console.ReadKey();
            MenuUserView.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<User>();

                var tagExists = repository.Get(id);
                if (tagExists is null)
                {
                    Console.WriteLine("Não foi possível localizar o usuário informado");
                    return;
                }

                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Usuário excluído com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}