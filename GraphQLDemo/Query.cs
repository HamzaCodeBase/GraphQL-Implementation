using GraphQLDemo.Models;

namespace GraphQLDemo
{
    public class Query
    {

        [UsePaging]

        [UseFiltering]
        [UseSorting]
        public IQueryable<User> GetUsers([Service] AppDbContext dbContext)
        {
            return dbContext.Users;
        }

        public User? GetUserById([Service] AppDbContext db, [DefaultValue(1)] int id) => db.Users.FirstOrDefault(u => u.Id == id);
    }

}
