using GraphQLDemo.Models;

namespace GraphQLDemo
{
    public class Mutation
    {
        public async Task<User> CreateUserAsync([Service] AppDbContext dbContext, User user)
        {
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateUserAsync([Service] AppDbContext dbContext, User user)
        {
            var existingUser = await dbContext.Users.FindAsync(user.Id);
            if (existingUser is null)
                return null;
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            await dbContext.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync([Service] AppDbContext dbContext, int id)
        {
            var user = await dbContext.Users.FindAsync(id);
            if (user is null)
                return false;
            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }

}
