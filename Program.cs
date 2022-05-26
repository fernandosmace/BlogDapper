using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Views.TagViews;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=a2t%JH!a@AgaxAG;trustservercertificate=true";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Load();

            Console.ReadKey();

            Database.Connection.Close();
        }


        private static void Load()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de Usuários");
            Console.WriteLine("2 - Gestão de Perfis");
            Console.WriteLine("3 - Gestão de Categorias");
            Console.WriteLine("4 - Gestão de Tags");
            Console.WriteLine("5 - Vincular Usuário à Perfil");
            Console.WriteLine("6 - Vincular Post à Tag");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    //MenuUserView.Load();
                    break;
                case 2:
                    //MenuRoleView.Load();
                    break;
                case 3:
                    //MenuCategoryView.Load();
                    break;
                case 4:
                    MenuTagView.Load();
                    break;
                case 5:
                    //MenuUserRoleView.Load();
                    break;
                case 6:
                    //MenuPostTagView.Load();
                    break;
                case 7:
                    //MeuReports.Load();
                    break;
                default:
                    Load();
                    break;
            }
        }

    }
}