using System;
using BlogDapper.Views.UserRoleView;

namespace Blog.Views.UserRoleView
{
    public class MenuUserRoleView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Vincular Usuário à Perfil");
            Console.WriteLine("-------------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuários com perfis");
            Console.WriteLine("2 - Adicionar permissão");
            Console.WriteLine("3 - Remover permissão");
            Console.WriteLine("4 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListUserRoleView.Load();
                    break;
                case 2:
                    CreateUserRoleView.Load();
                    break;
                case 3:
                    DeleteUserRoleView.Load();
                    break;
                case 4:
                    StartView.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}