using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Ilceler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilceler()
        {
            this.hastaneler = new HashSet<Hastaneler>();
        }
        [Key]
        public int ilceID { get; set; }
        public int sehirID { get; set; }
        public string ilceAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hastaneler> hastaneler { get; set; }
        public virtual Sehirler sehirler { get; set; }

    }
}
