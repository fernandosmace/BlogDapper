using System;
using Blog.Models;
using Blog.Repositories;
using Blog.Views.UserViews;

namespace Blog.Views.UserViews
{
    public class ChangePasswordUserView
    {
        public static void Load()
        {
            Console.WriteLine();
            Console.WriteLine("------------------------");
            Console.WriteLine("Alterar senha do Usuário");
            Console.WriteLine("------------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            if (CheckUser(id))
            {
                string currentPassword = null;
                Console.Write("Senha atual: ");
                while (true)
                {
                    var key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace &&
                        key.Key != ConsoleKey.Escape &&
                        key.Key != ConsoleKey.Spacebar)
                    {
                        Console.Write("*");
                        if (key.Key == ConsoleKey.Enter && currentPassword.Length > 0)
                        {
                            Console.WriteLine();
                            break;
                        }

                        currentPassword += key.KeyChar;
                    }
                }

                if (VerifyPassword(id, currentPassword))
                {
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
                        Update(new User
                        {
                            Id = id,
                            PasswordHash = BCrypt.Net.BCrypt.HashPassword(passwordA)
                        });
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("As senhas não são iguais!");
                    }
                }
                else
                {
                    Console.WriteLine("Senha inválida!");
                }
            }
            else
            {
                Console.WriteLine("Usuário não encontrado!");
            }

            Console.ReadKey();
            MenuUserView.Load();
        }
        private static bool CheckUser(int id)
        {
            var repository = new Repository<User>();
            var isCreated = repository.Get(id);

            if (isCreated is null)
            {
                return false;
            }

            return true;

        }

        private static bool VerifyPassword(int id, string password)
        {
            try
            {
                var repository = new Repository<User>();
                var user = repository.Get(id);

                return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível verificar a senha.");
                Console.WriteLine(ex.Message);
            }

            return false;
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

                user.Name = userExists.Name;
                user.Email = userExists.Email;
                user.Bio = userExists.Bio;
                user.Image = userExists.Image;
                user.Slug = userExists.Slug;

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