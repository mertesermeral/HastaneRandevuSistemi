using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Sehirler
    {
        public Sehirler()
        {
            this.Hastaneler = new HashSet<Hastaneler>();
            this.Ilceler = new HashSet<Ilceler>();
        }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        public int SehirlerID { get; set; }

        [Required]
        public string SehirAd { get; set; }

        // Navigation Properties
        public  ICollection<Ilceler> Ilceler { get; set; }
        // public virtual ICollection<Hastane> Hastane { get; set; }
        //public Nullable<int> HastaneID { get; set; }

        public virtual ICollection<Hastaneler> Hastaneler { get; set; }
    }
}
