using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Poliklinik
    {
        public Poliklinik()
        {
            this.Doktorlar = new HashSet<Doktor>();
        }

        [Key]
        public int PolID { get; set; }

        [Required]
        public string PolAd { get; set; }
     
        public int HastaneID { get; set; }      
        public  Hastaneler Hastane { get; set; }
     
        public ICollection<Doktor> Doktorlar { get; set; }
        

    }
}
