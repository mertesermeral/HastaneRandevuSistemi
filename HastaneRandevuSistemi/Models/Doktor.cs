using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }
        public string DoktorAd { get; set; }
        public Poliklinik Poliklinik { get; set; }
        //güncellendi
        
    }
}
