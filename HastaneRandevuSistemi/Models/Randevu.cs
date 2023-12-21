using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuID { get; set; }

        // [Required]
        public DateTime RandevuTarih { get; set; }

        //[Required]
        public string RandevuSaat { get; set; }

        // Foreign Key
        public int KullaniciID { get; set; }


        // Navigation Properties
        [ForeignKey("KullaniciID")]
        public virtual Kullanici Kullanici { get; set; }

        //public Nullable<int> RandevuTUR { get; set; }
        //public  RandevuTur RandevuTur { get; set; }


        [ForeignKey("DoktorId")]
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
    }
}
