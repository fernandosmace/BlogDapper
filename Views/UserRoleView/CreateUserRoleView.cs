using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Views.UserRoleView;

namespace BlogDapper.Views.UserRoleView
{
    public class CreateUserRoleView
    {
        public static void Load()
        {
            Console.WriteLine();
            Console.WriteLine("------------");
            Console.WriteLine("Vincular Usuário à Perfil");
            Console.WriteLine("------------");

            Console.Write("Id Usuário: ");
            var idUser = Int32.Parse(Console.ReadLine());

            if (CheckUser(idUser))
            {
                Console.Write("Id Role: ");
                var idRole = Int32.Parse(Console.ReadLine());

                if (CheckRole(idRole))
                {
                    Create(new UserRole
                    {
                        UserId = idUser,
                        RoleId = idRole
                    });
                }
                else
                {
                    Console.WriteLine("Não foi possível localizar o perfil informado");
                }
            }
            else
            {
                Console.WriteLine("Não foi possível localizar o usuário informado");
            }

            Console.ReadKey();
            MenuUserRoleView.Load();
        }

        private static bool CheckUser(int id)
        {
            var repository = new Repository<User>();
            var isCreated = repository.Get(id);

            if (isCreated is null)
            {
                return false;
            }

            return true;

        }
        private static bool CheckRole(int id)
        {
            var repository = new Repository<Role>();
            var isCreated = repository.Get(id);

            if (isCreated is null)
            {
                return false;
            }

            return true;

        }

        private static void Create(UserRole userRole)
        {
            try
            {
                var repository = new Repository<UserRole>();
                repository.Create(userRole);

                Console.WriteLine();
                Console.WriteLine("Usuário inserido com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}