using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HastaneRandevuSistemi.Controllers
{
    public class AdminPController : Controller
    {
        HastaneContext db = new HastaneContext();
        public IActionResult Index()
        {
            var degerler = db.Hastane.Include(h => h.Sehir).ToList();
            var degerler2 = db.Hastane.Include(h => h.Ilceler).ToList();
            return View(degerler);
            
        }
        [HttpGet]

        public ActionResult Ekleme()
        {
            List<SelectListItem> sehir = (from x in db.Sehirler.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.SehirAd,
                                              Value = x.SehirAd.ToString(),
                                          }).ToList();
            ViewBag.frms = sehir;

            List<SelectListItem> degerler = (from i in db.Ilce.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.IlceAd,
                                                 Value = i.IlcelerID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            ViewBag.SehirList = new SelectList(ilgetir(), "SehirlerID", "SehirAd");
            return View();
        }
        [HttpPost]
        public ActionResult Ekleme(Hastaneler p1)
        {
            Hastaneler ab = new Hastaneler();
            ab.HastaneAd = p1.HastaneAd;
            ab.SehirlerID = p1.SehirlerID;
            ab.IlcelerID = p1.IlcelerID;
            db.Hastane.Add(ab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var hstnlr = db.Hastane.Find(id);
            db.Hastane.Remove(hstnlr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Güncelle(int id)
        {
            var ur = db.Hastane.Find(id);
            List<SelectListItem> ils = (from x in db.Sehirler.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.SehirAd,
                                            Value = x.SehirlerID.ToString(),
                                        }).ToList();
            ViewBag.shr = ils;
            List<SelectListItem> ilces = (from i in db.Ilce.ToList()
                                          select new SelectListItem
                                          {
                                              Text = i.IlceAd,
                                              Value = i.IlcelerID.ToString(),
                                          }).ToList();
            ViewBag.ilc = ilces;
            return View("Güncelle", ur);
        }
        public ActionResult Guncel(Hastaneler p1)
        {
            var u = db.Hastane.Find(p1.HastaneID);
            u.HastaneAd = p1.HastaneAd;
            var fr = db.Sehirler.Where(m => m.SehirlerID == p1.Sehir.SehirlerID).FirstOrDefault();
            u.SehirlerID = fr.SehirlerID;
            var mrk = db.Ilce.Where(m => m.IlcelerID == p1.Ilceler.IlcelerID).FirstOrDefault();
            u.IlcelerID = mrk.IlcelerID;

            db.SaveChanges();
            return RedirectToAction("Index");
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
    }
}
