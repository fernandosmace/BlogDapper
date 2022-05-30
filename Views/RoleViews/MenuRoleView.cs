using System;

namespace Blog.Views.RoleViews
{
    public class MenuRoleView
    {

        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Gestão de Roles");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Roles");
            Console.WriteLine("2 - Cadastrar nova Role");
            Console.WriteLine("3 - Atualizar Role");
            Console.WriteLine("4 - Excluir Role");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListRoleView.Load();
                    break;
                case 2:
                    CreateRoleView.Load();
                    break;
                case 3:
                    UpdateRoleView.Load();
                    break;
                case 4:
                    //DeleteRoleView.Load();
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