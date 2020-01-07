using RealBlog.Models;
using System.Data.Entity;

namespace RealBlog.DAL
{
    public class BikerBlogDBContext:DbContext
    {
        /// <summary>
        /// Инициализируем Бд при первом обращении к контексту - вызываем конструктор
        /// </summary>
        static BikerBlogDBContext()
        {
            Database.SetInitializer(new BikerBlogDbInitializer());
        }
        public BikerBlogDBContext() : base("BikerBlogDatabase")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}