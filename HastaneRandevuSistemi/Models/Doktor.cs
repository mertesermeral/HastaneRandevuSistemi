using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Doktor
    {
        public Doktor()
        {
            this.randevular = new HashSet<Randevu>();
            this.kullanicilar = new HashSet<Kullanici>();
        }
        [Key]
        public int doktorID { get; set; }
        public string doktorAD { get; set; }
        public int hastaneID { get; set; }

        public int polID { get; set; }

        public Hastaneler hastaneler { get; set; }

        public Poliklinik poliklinikler { get; set; }

        public ICollection<Randevu> randevular {  get; set; }
        public ICollection<Kullanici> kullanicilar {  get; set; }
        
        
    }
}
