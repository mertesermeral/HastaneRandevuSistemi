using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Poliklinik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Poliklinik()
        {
            this.doktorlar = new HashSet<Doktor>();
        }
        [Key]
        public int polID { get; set; }
        public string polAD { get; set; }
        public Nullable<int> hastaneID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Doktor> doktorlar { get; set; }
        public virtual Hastaneler hastaneler { get; set; }


    }
}
