using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
// deneme 2
namespace HastaneRandevuSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        HastaneContext db= new HastaneContext();
        public IActionResult Index()
        {
            var degerler = db.Hastane.ToList();
            return View(degerler);
        }
        public ActionResult Cascading()
        {
            ViewBag.SehirList = new SelectList(ilgetir(), "SEHIRID", "SEHIRAD");
            return View();
        }
        public List<Sehirler> ilgetir()
        {
            List<Sehirler> sehirler = db.Sehirler.ToList();

            return sehirler;
        }
        public ActionResult ilcegetir(int SehirlerID)
        {
            List<Ilceler> selectlist = db.Ilce.Where(x => x.SehirlerID == SehirlerID).ToList();
            ViewBag.Ilcelist = new SelectList(selectlist, "IlcelerID", "IlceAd");
            return PartialView("ilcegoster");
        }
        public ActionResult hastanegetir(int IlcelerID)
        {
            List<Hastaneler> selectlist = db.Hastane.Where(x => x.IlcelerID == IlcelerID).ToList();
            ViewBag.Hastanelist = new SelectList(selectlist, "HastaneID", "HastaneAd");
            return PartialView("hastanegoster");
        }
        public ActionResult klinikgetir(int HastaneID)
        {
            List<Poliklinik> selectlist = db.Poliklinik.Where(x => x.HastaneID == HastaneID).ToList();
            ViewBag.Kliniklist = new SelectList(selectlist, "PoliklinikID", "PolAd");
            return PartialView("klinikgoster");
        }
        public ActionResult doktorgetir(int PolID)
        {
            List<Doktor> selectlist = db.Doktor.Where(x => x.PolID == PolID).ToList();
            ViewBag.Doktorlist = new SelectList(selectlist, "DoktorID", "DoktorAd");
            return PartialView("doktorgoster");
        }
    }
}
