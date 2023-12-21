using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.Randevular = new HashSet<Randevu>();
        }
        public int KullaniciID { get; set; }
        [Required(ErrorMessage = "Lütfen TC Kimlik No Giriniz", AllowEmptyStrings = false)]
        public string KullaniciTC { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz", AllowEmptyStrings = false)]
        public string KullaniciAd { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz", AllowEmptyStrings = false)]
        public string KullaniciSoyad { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime KullaniciDogum { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 hane olmalıdır")]
        public string KullaniciSifre { get; set; }
        [Compare("KullaniciSifre", ErrorMessage = "Şifre eşleşmiyor")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public int AilehID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> Randevular { get; set; }
        // public virtual Doktor doktorlar { get; set; }

        public ICollection<Doktor> Doktorlar { get; set; }
    }
}
