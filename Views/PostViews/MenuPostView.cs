using System;

namespace Blog.Views.PostViews
{
    public class MenuPostView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Gestão de Posts");
            Console.WriteLine("--------------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Posts");
            Console.WriteLine("2 - Cadastrar novo Post");
            Console.WriteLine("3 - Atualizar Post");
            Console.WriteLine("4 - Excluir Post");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    //ListPostView.Load();
                    break;
                case 2:
                    CreatePostView.Load();
                    break;
                case 3:
                    //UpdatePostView.Load();
                    break;
                case 4:
                    //DeletePostView.Load();
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