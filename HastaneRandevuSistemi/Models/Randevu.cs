using System.Numerics;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public Doktor Doktor { get; set; }
        public string Hasta_adi { get; set; }
        public DateTime RandevuGunu { get; set; }
    }
}
