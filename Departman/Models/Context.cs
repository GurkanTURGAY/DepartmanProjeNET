

using Microsoft.EntityFrameworkCore;

namespace Departman.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-99SLPDA\\SQLEXPRESS; database=Birimdb; integrated security=true; TrustServerCertificate=True;");
        }

        public DbSet<Birim> Birims { get; set; }
        public DbSet<Personel> Personels { get; set; }

    }
}
