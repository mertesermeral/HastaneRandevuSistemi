using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
namespace HastaneRandevuSistemi.Controllers
{
    public class KlinikAdminController : Controller
    {
        // GET: Kategoriler

        HastaneContext db = new HastaneContext();
        public ActionResult Index()
        {
            var degerler = db.Poliklinik.Include(h => h.Hastane).ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Ekleme()
        {
            List<SelectListItem> ils = (from x in db.Hastane.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.HastaneAd,
                                            Value = x.HastaneID.ToString(),
                                        }).ToList();
            ViewBag.klk = ils;
            return View();
        }
        [HttpPost]
        public ActionResult Ekleme(Poliklinik p1)
        {
            var ktg = db.Hastane.Where(m => m.HastaneID == p1.HastaneID).FirstOrDefault();
            p1.Hastane = ktg;
            db.Poliklinik.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var kln = db.Poliklinik.Find(id);
            db.Poliklinik.Remove(kln);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Güncelle(int id)
        {
            var klnk = db.Poliklinik.Find(id);
            List<SelectListItem> ils = (from x in db.Hastane.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.HastaneAd,
                                            Value = x.HastaneID.ToString(),
                                        }).ToList();
            ViewBag.klk = ils;
            return View("Güncelle",klnk);
        }
        public ActionResult Guncel(Poliklinik p1)
        {
            var k = db.Poliklinik.Find(p1.PolID);
            k.PolAd = p1.PolAd;
            var fr = db.Hastane.Where(m => m.HastaneID == p1.Hastane.HastaneID).FirstOrDefault();
            k.HastaneID = fr.HastaneID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}