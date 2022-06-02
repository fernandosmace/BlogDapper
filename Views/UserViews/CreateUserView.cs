using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.UserViews
{
    public class CreateUserView
    {
        public static void Load()
        {
            Console.WriteLine();
            Console.WriteLine("------------");
            Console.WriteLine("Novo Usuário");
            Console.WriteLine("------------");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            string passwordA = null;
            Console.Write("Senha: ");
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace &&
                    key.Key != ConsoleKey.Escape &&
                    key.Key != ConsoleKey.Spacebar)
                {
                    Console.Write("*");
                    if (key.Key == ConsoleKey.Enter && passwordA.Length > 0)
                    {
                        Console.WriteLine();
                        break;
                    }

                    passwordA += key.KeyChar;
                }
            }

            string passwordB = null;
            Console.Write("Repita a senha: ");
            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace &&
                    key.Key != ConsoleKey.Escape &&
                    key.Key != ConsoleKey.Spacebar)
                {
                    Console.Write("*");
                    if (key.Key == ConsoleKey.Enter && passwordB.Length > 0)
                    {
                        Console.WriteLine();
                        break;
                    }

                    passwordB += key.KeyChar;
                }
            }

            if (passwordA == passwordB)
            {
                Console.Write("Bio: ");
                var bio = Console.ReadLine();

                Console.Write("Image: ");
                var image = Console.ReadLine();

                Console.Write("Slug: ");
                var slug = Console.ReadLine();

                Create(new User
                {
                    Name = name,
                    Email = email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordA),
                    Bio = bio,
                    Image = image,
                    Slug = slug,
                });
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("As senhas não são iguais!");
            }



            Console.ReadKey();
            MenuUserView.Load();
        }

        private static void Create(User tag)
        {
            try
            {
                var repository = new Repository<User>();
                repository.Create(tag);

                Console.WriteLine();
                Console.WriteLine("Usuário inserido com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}