using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.PostViews
{
    public class CreatePostView
    {
        public static void Load()
        {
            Console.WriteLine("---------");
            Console.WriteLine("Novo Post");
            Console.WriteLine("---------");

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

            Create(new Post
            {
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

        private static void Create(Post post)
        {
            try
            {
                var repository = new Repository<Post>();
                repository.Create(post);

                Console.WriteLine();
                Console.WriteLine("Post inserido com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir o Post.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}