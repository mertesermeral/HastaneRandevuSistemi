using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Doktor
    {
        [Key]
        public int Id { get; set; }
        public string DoktorAd { get; set; }
        public int PolId { get; set; }
        public Poliklinik Poliklinik { get; set; }
    }
}
