using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Poliklinik
    {
        [Key]
        public int PolId { get; set; }
        public string PolAd { get; set; }
    }
}
