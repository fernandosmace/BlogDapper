using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.TagViews
{
    public class CreateTagView
    {
        public static void Load()
        {
            Console.WriteLine("Nova Tags");
            Console.WriteLine("-------------");

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new Tag
            {
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuTagView.Load();
        }

        private static void Create(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>();
                repository.Create(tag);

                Console.WriteLine();
                Console.WriteLine("Tag inserida com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível inserir a tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}