using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Models
{
    public class HastaneContext: DbContext
    {
        public DbSet<Doktor> Doktorlar { get; set; }
        public DbSet<Poliklinik> Poliklinikler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Hastaneler> Hastaneler { get; set; }
        public DbSet<Ilceler> Ilceler {  get; set; }
        public DbSet<Kullanici> Kullanicilar {  get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<RandevuTur> RandevuTur { get; set; }
        public DbSet<Sehirler> Sehirler { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hastane;Trusted_Connection=True;");
        }

    }
}
