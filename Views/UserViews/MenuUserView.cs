using System;

namespace Blog.Views.UserViews
{
    public class MenuUserView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Gestão de Usuários");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Usuários");
            Console.WriteLine("2 - Cadastrar novo Usuário");
            Console.WriteLine("3 - Atualizar Usuário");
            Console.WriteLine("4 - Excluir Usuário");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListUserView.Load();
                    break;
                case 2:
                    CreateUserView.Load();
                    break;
                case 3:
                    UpdateUserView.Load();
                    break;
                case 4:
                    DeleteUserView.Load();
                    break;
                case 5:
                    StartView.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}