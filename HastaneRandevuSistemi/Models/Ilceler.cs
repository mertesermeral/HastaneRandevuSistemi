using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Ilceler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ilceler()
        {
            this.Hastaneler = new HashSet<Hastaneler>();
        }
        [Key]
        public int IlcelerID { get; set; }

        [Required]
        public string IlceAd { get; set; }

        public ICollection<Hastaneler> Hastaneler { get; set; }

    }
}