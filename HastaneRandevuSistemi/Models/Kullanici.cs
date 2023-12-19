using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanici()
        {
            this.randevular = new HashSet<Randevu>();
        }
        public int kullaniciID { get; set; }
        [Required(ErrorMessage = "Lütfen TC Kimlik No Giriniz", AllowEmptyStrings = false)]
        public string kullaniciTC { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz", AllowEmptyStrings = false)]
        public string kullaniciAD { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz", AllowEmptyStrings = false)]
        public string kullaniciSOYAD { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public System.DateTime kullaniciDOGUM { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 hane olmalıdır")]
        public string kullaniciSIFRE { get; set; }
        [Compare("kullaniciSIFRE", ErrorMessage = "Şifre eşleşmiyor")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public int ailehID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Randevu> randevular { get; set; }
        public virtual Doktor doktorlar { get; set; }
    }
}
