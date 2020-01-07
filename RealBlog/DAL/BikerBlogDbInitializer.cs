using RealBlog.Models;
using System.Data.Entity;

namespace RealBlog.DAL
{
    internal class BikerBlogDbInitializer : DropCreateDatabaseIfModelChanges<BikerBlogDBContext>
    {
        protected override void Seed(BikerBlogDBContext context)
        {
            User defaultUser = new User
            {
                NickName = "test",
                Password = "test123",
                Email = "test@test.ru"
            };
            context.Users.Add(defaultUser);
            context.SaveChanges();
        }
    }
}