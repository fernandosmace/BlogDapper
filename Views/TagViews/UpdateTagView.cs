using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Views.TagViews
{
    public class UpdateTagView
    {
        public static void Load()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------");
            Console.WriteLine("Atualização de Tag");
            Console.WriteLine("------------------");

            Console.Write("Id: ");
            var id = Int32.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Update(new Tag
            {
                Id = id,
                Name = name,
                Slug = slug
            });

            Console.ReadKey();
            MenuTagView.Load();
        }

        private static void Update(Tag tag)
        {
            try
            {
                var repository = new Repository<Tag>();

                var tagExists = repository.Get(tag.Id);
                if (tagExists is null)
                {
                    Console.WriteLine("Não foi possível localizar a Tag informada");
                    return;
                }

                repository.Update(tag);

                Console.WriteLine();
                Console.WriteLine("Tag atualizada com sucesso!");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Não foi possível atualizar a tag.");
                Console.WriteLine(ex.Message);
            }
        }
    }
}