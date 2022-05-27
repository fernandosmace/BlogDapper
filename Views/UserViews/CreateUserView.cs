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

            Console.Write("Senha: ");
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(Console.ReadLine());

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
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug,
            });

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