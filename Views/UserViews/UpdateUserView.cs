using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.UserViews
{
    public class UpdateUserView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("Atualização de Usuário");
            Console.WriteLine("----------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

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

            Update(new User
            {
                Id = id,
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

        private static void Update(User user)
        {
            try
            {
                var repository = new Repository<User>();

                var userExists = repository.Get(user.Id);
                if (userExists is null)
                {
                    Console.WriteLine("Não foi possível localizar o usuário informado");
                    return;
                }

                repository.Update(user);

                Console.WriteLine();
                Console.WriteLine("Usuário atualizado com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o usuário.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}