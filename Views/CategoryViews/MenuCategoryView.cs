using System;

namespace Blog.Views.CategoryViews
{
    public class MenuCategoryView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Gestão de Categorias");
            Console.WriteLine("--------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Categorias");
            Console.WriteLine("2 - Cadastrar nova Categoria");
            Console.WriteLine("3 - Atualizar Categoria");
            Console.WriteLine("4 - Excluir Categoria");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListCategoryView.Load();
                    break;
                case 2:
                    //CreateCategoryView.Load();
                    break;
                case 3:
                    //UpdateCategoryView.Load();
                    break;
                case 4:
                    //DeleteCategoryView.Load();
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