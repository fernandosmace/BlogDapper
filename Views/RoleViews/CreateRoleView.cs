using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.RoleViews
{
    public class CreateRoleView
    {

        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-----------");
            Console.WriteLine("Novo Perfil");
            Console.WriteLine("-----------");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Role
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuRoleView.Load();
        }

        private static void Create(Role role)
        {
            try
            {
                var repository = new Repository<Role>();
                repository.Create(role);

                Console.WriteLine();
                Console.WriteLine("Perfil inserido com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir o perfil.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}