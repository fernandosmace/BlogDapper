using System;
using Blog.Repositories;
using Blog.Views.UserRoleView;

namespace BlogDapper.Views.UserRoleView
{
    public class ListUserRoleView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------------");
            Console.WriteLine("Lista de Usuários com Perfis");
            Console.WriteLine("----------------------------");

            List();

            Console.ReadKey();
            MenuUserRoleView.Load();
        }

        private static void List()
        {
            var repository = new UserRepository();
            var users = repository.GetWithRoles();
            foreach (var item in users)
            {
                Console.WriteLine($"Usuário: {item.Name} (Id :{item.Id})");
                Console.Write($"    Perfis: ");

                if (item.Roles.Count != 0)
                {
                    foreach (var role in item.Roles)
                    {
                        Console.WriteLine();
                        Console.Write($"        {role.Name} (Id: {role.Id})");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum perfil vinculado ao usuário");
                }
                Console.WriteLine();
                Console.WriteLine($"---");
            }
        }
    }
}
