using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Doktor
    {
        public Doktor()
        {
            this.Randevular = new HashSet<Randevu>();
            this.Kullanicilar = new HashSet<Kullanici>();
        }
        [Key]
        public int DoktorID { get; set; }

        public string DoktorAd { get; set; }


        [ForeignKey("HastaneId")]
        public int HastaneID { get; set; }
        public Hastaneler Hastane { get; set; }


        public ICollection<Randevu> Randevular { get; set; }   

        public ICollection<Kullanici> Kullanicilar { get; set; }

    }
}
