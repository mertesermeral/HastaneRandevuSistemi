using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Hastaneler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hastaneler()
        {
            this.Doktorlar = new HashSet<Doktor>();
            this.Poliklinikler = new HashSet<Poliklinik>();
        }
        [Key]
        public int HastaneID { get; set; }
    
        public string HastaneAd { get; set; }

        public int IlcelerID { get; set; }
        
        public Ilceler Ilceler { get; set; }

        public int? SehirlerID { get; set; }
        public Sehirler Sehir { get; set; }

        public  ICollection<Doktor> Doktorlar { get; set; }
              
        public ICollection<Poliklinik> Poliklinikler { get; set; }

    }
}
