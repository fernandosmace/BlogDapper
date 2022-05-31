using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class UserRepository : Repository<User>
    {
        public List<User> GetWithRoles()
        {
            var query = @"
                SELECT
                    [User].*,
                    [Role].*
                FROM
                    [User]
                    LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
                    LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]";

            var users = new List<User>();
            var items = Database.Connection.Query<User, Role, User>(
                query,
                (user, role) =>
                {
                    var usr = users.FirstOrDefault(x => x.Id == user.Id);
                    if (usr == null)
                    {
                        usr = user;

                        if (role is not null)
                            usr.Roles.Add(role);

                        users.Add(usr);
                    }
                    else
                        usr.Roles.Add(role);

                    return user;
                }, splitOn: "Id");
            return users;
        }

        public UserRole GetUserRole(UserRole userRole)
        {
            var query = @"SELECT
                            [UserId],
                            [RoleId]
                        FROM
                            [UserRole]
                        WHERE
                            [UserId] = @UserId
                            [RoleId] = @RoleId";

            var result = Database.Connection.QueryFirst<UserRole>(query,
            new
            {
                UserId = userRole.UserId,
                RoleId = userRole.RoleId
            });

            var item = new UserRole
            {
                UserId = result.UserId,
                RoleId = result.RoleId
            };

            return item;
        }
    }
}