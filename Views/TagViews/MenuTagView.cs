using System;

namespace Blog.Views.TagViews
{
    public class MenuTagView
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Gestão de Tags");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar Tags");
            Console.WriteLine("2 - Cadastrar nova Tag");
            Console.WriteLine("3 - Atualizar Tag");
            Console.WriteLine("4 - Excluir Tag");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine();

            var option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    ListTagView.Load();
                    break;
                case 2:
                    CreateTagView.Load();
                    break;
                case 3:
                    UpdateTagView.Load();
                    break;
                case 4:
                    //DeleteTagView.Load();
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