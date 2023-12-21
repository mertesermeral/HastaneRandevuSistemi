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

        //[Required]
        public string HastaneAd { get; set; }





        // Navigation Properties
        //[ForeignKey("IlceID")]
        public int? IlceId { get; set; }
        //public Ilceler Ilceler { get; set; }




        // [ForeignKey("SehirID")]
        public int SehirId { get; set; }
        // public Sehirler Sehirler { get; set; }





        // Diğer ilişkiler
        public virtual ICollection<Doktor> Doktorlar { get; set; }
        // Daha fazla ilişki eklenebilir

        public ICollection<Poliklinik> Poliklinikler { get; set; }

    }
}
