namespace HastaneRandevuSistemi.Models
{
    public class Class1
    {
        public int SehirID { get; set; }
        public int IlcelerID { get; set; }
        public int HastaneID { get; set; }
        public int PolID { get; set; }
        public int DoktorID { get; set; }
        public string HastaneAd { get; set; }
        public virtual Ilceler Ilceler { get; set; }
        public virtual Sehirler Sehirler { get; set; }
    }
}
