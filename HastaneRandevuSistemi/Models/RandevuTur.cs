using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class RandevuTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RandevuTur()
        {
            this.randevular = new HashSet<Randevu>();
        }
        [Key]
        public int randevuTUR { get; set; }
        public string randevuAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> randevular { get; set; }
    }
}
