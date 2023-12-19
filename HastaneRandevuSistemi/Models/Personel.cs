using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Personel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public int PID { get; set; }
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz", AllowEmptyStrings = false)]
        public string PUsername { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Giriniz", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Şifreniz en az 6 hane olmalıdır")]
        public string PPasword { get; set; }
    }
}
