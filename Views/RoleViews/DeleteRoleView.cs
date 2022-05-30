using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.RoleViews
{
    public class DeleteRoleView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("Exclusão de Perfil");
            Console.WriteLine("------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Delete(id);

            Console.ReadKey();
            MenuRoleView.Load();
        }

        private static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Role>();

                var roleExists = repository.Get(id);
                if (roleExists is null)
                {
                    Console.WriteLine("Não foi possível localizar o Perfil informada");
                    return;
                }

                repository.Delete(id);

                Console.WriteLine();
                Console.WriteLine("Perfil excluída com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}