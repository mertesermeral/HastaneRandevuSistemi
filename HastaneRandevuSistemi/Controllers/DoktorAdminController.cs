using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList;
namespace HastaneRandevuSistemi.Controllers
{
    public class DoktorAdminController : Controller
    {
        HastaneContext db = new HastaneContext();
        public ActionResult Index(string ara, int sayfa = 1)
        {
            List<Doktor> degerler = db.Doktor.ToList();
            var degerler2 = db.Doktor.Include(h => h.Hastane).ToList();
            var degerler3 = db.Doktor.Include(h => h.Pol).ToList();

            return View(db.Doktor.Where(s => s.DoktorAd.ToLower().Contains(ara) || ara == null).ToList().ToPagedList(sayfa, 15));
        }
        Class1 cs = new Class1();
        public ActionResult Ekleme()
        {
            List<SelectListItem> firmas = (from x in db.Sehirler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.SehirAd,
                                               Value = x.SehirlerID.ToString(),
                                           }).ToList();
            ViewBag.frms = firmas;

            List<SelectListItem> degerler = (from i in db.Hastane.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.HastaneAd,
                                                 Value = i.HastaneID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            List<SelectListItem> marks = (from n in db.Poliklinik.ToList()
                                          select new SelectListItem
                                          {
                                              Text = n.PolAd,
                                              Value = n.PolID.ToString(),
                                          }).ToList();
            ViewBag.mrklr = marks;
            ViewBag.HastaList = new SelectList(hastaneget(), "HastaneID", "HastaneAd");
            return View();
        }
        [HttpPost]
        public ActionResult Ekleme(Doktor p1)
        {
            Doktor ab = new Doktor();
            ab.HastaneID = p1.HastaneID;
            ab.PolID = p1.PolID;
            ab.DoktorAd = p1.DoktorAd;

            db.Doktor.Add(ab);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var urnler = db.Doktor.Find(id);
            db.Doktor.Remove(urnler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Güncelle(int id)
        {
            var ur = db.Doktor.Find(id);
            List<SelectListItem> degerler = (from i in db.Hastane.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.HastaneAd,
                                                 Value = i.HastaneID.ToString(),
                                             }).ToList();
            ViewBag.dgr = degerler;
            List<SelectListItem> marks = (from n in db.Poliklinik.ToList()
                                          select new SelectListItem
                                          {
                                              Text = n.PolAd,
                                              Value = n.PolID.ToString(),
                                          }).ToList();
            ViewBag.mrklr = marks;
            return View("Güncelle", ur);
        }
        public ActionResult Guncel(Doktor p1)
        {
            var u = db.Doktor.Find(p1.DoktorID);         
            var fr = db.Hastane.Where(m => m.HastaneID == p1.Hastane.HastaneID).FirstOrDefault();
            u.HastaneID = fr.HastaneID;
            var mrk = db.Poliklinik.Where(m => m.PolID == p1.Pol.PolID).FirstOrDefault();
            u.PolID = mrk.PolID;
            u.DoktorAd = p1.DoktorAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public List<Hastaneler> hastaneget()
        {
            List<Hastaneler> hastaneler = db.Hastane.ToList();

            return hastaneler;
        }


        public ActionResult klinikgetir(int HASTANEID)
        {
            List<Poliklinik> selectlist = db.Poliklinik.Where(x => x.HastaneID == HASTANEID).ToList();
            ViewBag.Kliniklist = new SelectList(selectlist, "PolID", "PolAd");
            return PartialView("klinikgoster");
        }
    }
}
