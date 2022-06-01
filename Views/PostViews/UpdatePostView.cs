using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.PostViews
{
    public class UpdatePostView
    {
        public static void Load()
        {
            Console.WriteLine("--------------");
            Console.WriteLine("Atualizar Post");
            Console.WriteLine("--------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Console.Write("Título: ");
            var title = Console.ReadLine();

            Console.Write("Texto: ");
            var body = Console.ReadLine();

            Console.Write("Resumo: ");
            var summary = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Console.Write("Id da Categoria: ");
            var categoryId = Int32.Parse(Console.ReadLine());

            Console.Write("Id do Usuário autor: ");
            var authorId = Int32.Parse(Console.ReadLine());

            Update(new Post
            {
                Id = id,
                Title = title,
                Body = body,
                Summary = summary,
                Slug = slug,
                CreateDate = DateTime.Now,
                LastUpdateDate = DateTime.Now,
                CategoryId = categoryId,
                AuthorId = authorId
            });

            Console.ReadKey();
            MenuPostView.Load();
        }

        private static void Update(Post post)
        {
            try
            {
                var repository = new Repository<Post>();

                var postExists = repository.Get(post.Id);
                if (postExists is null)
                {
                    Console.WriteLine("Não foi possível localizar o Post informado");
                    return;
                }

                repository.Create(post);

                Console.WriteLine();
                Console.WriteLine("Post atualizado com sucesso!");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar o Post.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}