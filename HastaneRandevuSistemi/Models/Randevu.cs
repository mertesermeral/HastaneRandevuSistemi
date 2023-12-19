using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int No { get; set; }
        public Doktor Doktor { get; set; }
        public Poliklinik Poliklinik { get; set; }
        public string Hasta_adi { get; set; }
        public DateTime RandevuGunu { get; set; }
    }
}
