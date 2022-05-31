using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.UserRoleView
{
    public class DeleteUserRoleView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("-------------------");
            Console.WriteLine("Remover permissão");
            Console.WriteLine("-------------------");

            Console.Write("Id Usuário: ");
            var idUser = Int32.Parse(Console.ReadLine());

            if (CheckUser(idUser))
            {
                Console.Write("Id Role: ");
                var idRole = Int32.Parse(Console.ReadLine());

                if (CheckRole(idRole))
                {
                    Delete(new UserRole
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

        private static void Delete(UserRole userRole)
        {
            try
            {
                var repository = new UserRepository();

                repository.DeleteUserRole(userRole);

                Console.WriteLine();
                Console.WriteLine("Permissão excluída com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível excluir a permissão.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}