using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Models
{
    public class HastaneContext: DbContext
    {
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hastane;Trusted_Connection=True;");
        }

    }
}
