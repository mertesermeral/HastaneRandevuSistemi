namespace HastaneRandevuSistemi.Models
{
    public class Sehirler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sehirler()
        {
            this.hastaneler = new HashSet<Hastaneler>();
            this.ilceler = new HashSet<Ilceler>();
        }

        public int sehirID { get; set; }
        public string sehirAD { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hastaneler> hastaneler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ilceler> ilceler { get; set; }
    }
}
