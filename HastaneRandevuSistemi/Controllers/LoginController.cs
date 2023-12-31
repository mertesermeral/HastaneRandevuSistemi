using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace HastaneRandevuSistemi.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login düzenlendi
        HastaneContext db = new HastaneContext();
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Register(Kullanici U)
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
            
            return View(U);
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Kullanici US)
        {
            var checkLogin = db.Kullanici.Where(x => x.KullaniciTC.Equals(US.KullaniciTC) && x.KullaniciSifre.Equals(US.KullaniciSifre)).FirstOrDefault();

            // var checkLogin = // Kullanıcı doğrulama işlemini burada gerçekleştirin

            if (checkLogin != null)
            {
                // Kullanıcı bilgilerini session'a kaydet
                HttpContext.Session.SetString("KullaniciTCSS", checkLogin.KullaniciTC.ToString());

                // TempData kullanarak kullanıcı adını sakla
                TempData["UserName"] = checkLogin.KullaniciAd;

                // Kullanıcı için kimlik doğrulama cookie'si oluştur
                var claims = new List<Claim>
                {
                     new Claim(ClaimTypes.Name, checkLogin.KullaniciTC)
                };


                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    // Cookie ayarları burada yapılabilir
                    IsPersistent = false
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Başarılı giriş sonrası ana sayfaya yönlendir
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısızsa kullanıcıyı bilgilendir
                ViewBag.Notification = "Yanlış TC veya şifre";
            }

            // Giriş sayfasına geri dön
            return View();


            //if (checkLogin != null)
            //{
            //    HttpContext.Session.SetString("KullaniciTCSS", US.KullaniciTC.ToString());
            //    //Session["KullaniciTCSS"] = US.KullaniciTC.ToString();
            //    TempData["UserName"] = checkLogin.KullaniciAd;
            //   FormsAuthentication.SetAuthCookie(US.KullaniciTC, false);
            //    return RedirectToAction("Index", "Home");
            //}
            //else
            //{
            //    ViewBag.Notification = "Yanlış TC veya şifre";
            //}
            //return View();
        }
        [HttpGet]
        public ActionResult PersonelG()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult PersonelG(Personel PS)
        {
            var checkLogin = db.Personel.Where(x => x.PUsername.Equals(PS.PUsername) && x.PPasword.Equals(PS.PPasword)).FirstOrDefault();
            if (checkLogin != null)
            {
                HttpContext.Session.SetString("PUsernameSS", PS.PUsername.ToString());

                return RedirectToAction("Index", "AdminP");
            }
            else
            {
                ViewBag.Notification = "Yanlış kullanıcı adı veya şifre";
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            // Kullanıcının kimlik doğrulamasını sonlandır
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Kullanıcıyı giriş sayfasına yönlendir
            return RedirectToAction("Login", "Login");
        }
    }
}
