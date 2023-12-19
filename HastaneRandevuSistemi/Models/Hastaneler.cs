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
        public int hastaneID { get; set; }
        public int sehirID { get; set; }
        public int ilceID { get; set; }
        public string hastaneAD { get; set;}

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Doktor> Doktorlar { get; set; }
        public Ilceler ılceler { get; set; }
        public Sehirler sehirler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<Poliklinik> Poliklinikler { get; set; }
    }
}
