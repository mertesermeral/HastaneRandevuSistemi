using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HastaneRandevuSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login düzenlendi
        HastaneContext db = new HastaneContext();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Kullanici U)
        {
            if (ModelState.IsValid)
            {
                using (HastaneContext dc = new HastaneContext())
                {
                    if (dc.Kullanici.Any(x => x.KullaniciTC == U.KullaniciTC))
                    {
                        ViewBag.DuplicateMessage = "Kullanıcı zaten mevcut";
                        return View(U);
                    }
                    U.AilehID = 2074;
                    dc.Kullanici.Add(U);
                    dc.SaveChanges();
                    ModelState.Clear();
                    U = null;
                    ViewBag.Message = "Kaydınız başarıyla tamamlanmıştır";
                }
            }
            return View(U);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Kullanici US)
        {
            var checkLogin = db.Kullanici.Where(x => x.KullaniciTC.Equals(US.KullaniciTC) && x.KullaniciSifre.Equals(US.KullaniciSifre)).FirstOrDefault();
            if (checkLogin != null)
            {
                HttpContext.Session.SetString("KullaniciTCSS", US.KullaniciTC.ToString());
                //Session["KullaniciTCSS"] = US.KullaniciTC.ToString();
                TempData["UserName"] = checkLogin.KullaniciAd;
                FormsAuthentication.SetAuthCookie(US.KullaniciTC, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Yanlış TC veya şifre";
            }
            return View();
        }
        [HttpGet]
        public ActionResult PersonelG()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PersonelG(Personel PS)
        {
            var checkLogin = db.Personel.Where(x => x.PUsername.Equals(PS.PUsername) && x.PPasword.Equals(PS.PPasword)).FirstOrDefault();
            if (checkLogin != null)
            {
                HttpContext.Session.SetString("PUsernameSS", PS.PUsername.ToString());
                //Session["PUsernameSS"] = PS.PUsername.ToString();

                return RedirectToAction("Index", "AdminP");
            }
            else
            {
                ViewBag.Notification = "Yanlış kullanıcı adı veya şifre";
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }
    }
}
