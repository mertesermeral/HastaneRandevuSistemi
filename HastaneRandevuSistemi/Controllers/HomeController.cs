using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

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
            var degerler = db.Hastane.Include(h=> h.Sehir).ToList();
            var degerler2 = db.Hastane.Include(h=> h.Ilceler).ToList();
            
            return View(degerler);
        }
        public ActionResult Cascading()
        {
            ViewBag.SehirList = new SelectList(ilgetir(), "SehirlerID", "SehirAd");
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
            ViewBag.Kliniklist = new SelectList(selectlist, "PolID", "PolAd");
            return PartialView("klinikgoster");
        }
        public ActionResult doktorgetir(int PolID)
        {
            List<Doktor> selectlist = db.Doktor.Where(x => x.PolID == PolID).ToList();
            ViewBag.Doktorlist = new SelectList(selectlist, "DoktorID", "DoktorAd");
            return PartialView("doktorgoster");
        }
        public ActionResult AsiRandevu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AsiRandevuAl(string data)
        {
            Randevu rande = new Randevu();
            var dataObject = JsonConvert.DeserializeObject<Randevu>(data);
            var kullaniciadi = User.Identity.Name;
            var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciTC == kullaniciadi);
            rande.KullaniciID = kullanici.KullaniciID;
            rande.DoktorID = dataObject.DoktorID;
            rande.RandevuTarih = dataObject.RandevuTarih;
            rande.RandevuSaat = dataObject.RandevuSaat;
            rande.TurID = dataObject.TurID;

            db.Randevu.Add(rande);
            db.SaveChanges();
            return Json(true);
        }
        public ActionResult AileHekimi()
        {

            return View();
        }
        [HttpPost]
        public ActionResult AilehekimiRandevuAl(string data)
        {
            Randevu rande = new Randevu();
            var dataObject = JsonConvert.DeserializeObject<Randevu>(data);
            var kullaniciadi = User.Identity.Name;
            var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciTC == kullaniciadi);
            rande.KullaniciID = kullanici.KullaniciID;
            rande.DoktorID = dataObject.DoktorID;
            rande.RandevuTarih = dataObject.RandevuTarih;
            rande.RandevuSaat = dataObject.RandevuSaat;
            rande.TurID = dataObject.TurID;
            db.Randevu.Add(rande);
            db.SaveChanges();
            return Json(true);
        }
        public ActionResult Arama()
        {
            var degerler3 = db.Doktor.Include(h => h.Hastane).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Arama(Class1 id)
        {
            var model = db.Doktor.Where(x => x.PolID == id.PolID).ToList();
            var firma = db.Doktor.Where(x => x.PolID == id.PolID).Select(x => x.DoktorID).FirstOrDefault();
            var degerler = db.Doktor.Include(h => h.Hastane).ToList();
            var degerler2 = db.Doktor.Include(h => h.Pol).ToList();
            ViewBag.viewfirma = firma;
            return View("Arama", model);
        }
        public ActionResult Doktor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoktorRandevuAl(string data, Doktor p1)
        {
            var u = db.Doktor.Find(p1.DoktorID);
            Randevu rande = new Randevu();
            var dataObject = JsonConvert.DeserializeObject<Randevu>(data);
            var kullaniciadi = User.Identity.Name;
            var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciTC == kullaniciadi);
            rande.KullaniciID = kullanici.KullaniciID;
            rande.DoktorID = dataObject.DoktorID;
            rande.RandevuTarih = dataObject.RandevuTarih;
            rande.RandevuSaat = dataObject.RandevuSaat;
            rande.TurID = dataObject.TurID;
            db.Randevu.Add(rande);
            db.SaveChanges();
            return Json(true);
        }
        public ActionResult Goster()
        {
            var kullaniciadi = User.Identity.Name;
            var kullanici = db.Kullanici.FirstOrDefault(x => x.KullaniciTC == kullaniciadi);
            var model = db.Randevu.Where(x => x.KullaniciID == kullanici.KullaniciID).ToList();
            return View(model);
        }
    }
}
