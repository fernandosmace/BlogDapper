using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.RoleViews
{
    public class UpdateRoleView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("Atualização de Perfil");
            Console.WriteLine("------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            var name = Console.ReadLine();
            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Role
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleView.Load();
        }

        private static void Update(Role role)
        {
            try
            {
                var repository = new Repository<Role>();

                var roleExists = repository.Get(role.Id);
                if (roleExists is null)
                {
                    Console.WriteLine("Não foi possível localizar o Perfil informado");
                    return;
                }

                repository.Update(role);

                Console.WriteLine();
                Console.WriteLine("Perfil atualizado com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o perfil.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}