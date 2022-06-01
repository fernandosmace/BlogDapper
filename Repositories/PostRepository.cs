using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Dapper;

namespace Blog.Repositories
{
    public class PostRepository
    {
        public List<Post> Get()
        {
            var query = @"
                SELECT
                    [Post].*,
                    [Category].*,
                    [User].*
                FROM
                    [Post]
                    LEFT JOIN [Category] ON [Category].[Id] = [Post].[CategoryId]
                    LEFT JOIN [User] ON [User].[Id] = [Post].[AuthorId]";

            var posts = new List<Post>();
            var items = Database.Connection.Query<Post, Category, User, Post>(
                query,
                (post, category, author) =>
                {
                    var pst = posts.FirstOrDefault(x => x.Id == post.Id);
                    if (pst == null)
                    {
                        pst = post;
                        pst.Category = category;
                        pst.Author = author;

                        posts.Add(pst);
                    }

                    return post;
                }, splitOn: "Id");
            return posts;
        }
    }
}