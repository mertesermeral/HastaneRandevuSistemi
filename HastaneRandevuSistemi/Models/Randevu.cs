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

        public Kullanici Kullanici { get; set; }

       

        public int TurID { get; set; }

        public Tur Tur { get; set; }

  
        public int DoktorID { get; set; }
        public Doktor Doktor { get; set; }
    }
}
