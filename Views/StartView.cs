using System;
using Blog.Views.CategoryViews;
using Blog.Views.PostViews;
using Blog.Views.RoleViews;
using Blog.Views.UserRoleView;
using Blog.Views.UserViews;

namespace Blog.Views
{
    public class StartView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuários");
            Console.WriteLine("2 - Gestão de Perfis");
            Console.WriteLine("3 - Gestão de Categorias");
            Console.WriteLine("4 - Gestão de Posts");
            Console.WriteLine("5 - Gestão de Permissões");
            Console.WriteLine("6 - Relatórios");
            Console.WriteLine("7 - Sair");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserView.Load();
                    break;
                case 2:
                    MenuRoleView.Load();
                    break;
                case 3:
                    MenuCategoryView.Load();
                    break;
                case 4:
                    MenuPostView.Load();
                    break;
                case 5:
                    MenuUserRoleView.Load();
                    break;
                case 6:
                    //MeuReports.Load();
                    break;
                case 7:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    Load();
                    break;
            }
        }
    }
}