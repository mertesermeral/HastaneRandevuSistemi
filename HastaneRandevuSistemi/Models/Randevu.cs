using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        public int randevuID { get; set; }
        public int kullaniciID { get; set; }
        public int doktorID { get; set; }
        public string randevuTARIH { get; set; }
        public string randevuSAAT { get; set; }
        public Nullable<int> randevuTUR { get; set; }

        public virtual Doktor doktorlar { get; set; }
        public virtual RandevuTur tur { get; set; }
        public virtual Kullanici kullanici { get; set; }
    }
}
