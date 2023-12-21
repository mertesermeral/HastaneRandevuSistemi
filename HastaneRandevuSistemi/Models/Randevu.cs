using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        public DateTime RandevuTarih { get; set; }

        public string RandevuSaat { get; set; }

        public int KullaniciID { get; set; }

        [ForeignKey("KullaniciID")]
        public virtual Kullanici Kullanici { get; set; }
        [ForeignKey("DoktorId")]
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
    }
}
