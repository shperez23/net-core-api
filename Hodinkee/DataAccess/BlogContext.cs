using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BlogContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<TypesPost> TypesPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //esto se parametriza en el json
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Hodinkee");
        }


    }
}
