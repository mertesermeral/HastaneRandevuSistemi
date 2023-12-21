using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneRandevuSistemi.Models
{
    public class Poliklinik
    {
        public Poliklinik()
        {
            this.Doktorlar = new HashSet<Doktor>();
        }

        [Key]
        public int PolID { get; set; }

        [Required]
        public string PolAd { get; set; }

        // Navigation Properties
        //  public virtual ICollection<Hastane> Hastane { get; set; }

        public Nullable<int> HastaneID { get; set; }      //boş bırakılabilir tanımlamıyalım bence
        public virtual Hastaneler Hastane { get; set; }

        // Diğer ilişkiler
        public virtual ICollection<Doktor> Doktorlar { get; set; }
        // Daha fazla ilişki eklenebilir

    }
}
