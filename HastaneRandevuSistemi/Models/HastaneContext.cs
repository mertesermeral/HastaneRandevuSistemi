using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Models
{
    public class HastaneContext: DbContext
    {
        public DbSet<Doktor> Doktor { get; set; }
        public DbSet<Poliklinik> Poliklinik { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<Hastaneler> Hastane { get; set; }
        public DbSet<Ilceler> Ilce {  get; set; }
        public DbSet<Kullanici> Kullanici {  get; set; }
        public DbSet<Personel> Personel { get; set; }
        public DbSet<RandevuTur> RandevuTur { get; set; }
        public DbSet<Sehirler> Sehirler { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Hastane;Trusted_Connection=True;");
        }

    }
}
