using HastaneRandevuSistemi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HastaneRandevuSistemi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciApiController : ControllerBase
    {
        HastaneContext k= new HastaneContext();
        // GET: api
        [HttpGet]
        public List<Kullanici> Get()
        {
            return k.Kullanici.ToList();
        }
        // GET api
        [HttpGet("{id}")]
        public Kullanici Get(int id)
        {
            var x = k.Kullanici.FirstOrDefault(y=> y.KullaniciID == id);
            return x;
        }

        // POST api
        [HttpPost]
        public void Post([FromBody] Kullanici y)
        {
                k.Kullanici.Add(y);
                k.SaveChanges();
        }

        // PUT api
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Kullanici y)
        {
            var y1= k.Kullanici.FirstOrDefault(x=>x.KullaniciID==id);
            if (y1==null)
            {
                return NotFound();
            }
            else
            {
                y1.KullaniciAd= y.KullaniciAd;
                y1.KullaniciSoyad = y.KullaniciSoyad;

                k.Update(y1);
                k.SaveChanges();
                return Ok();
            }

        }

        // DELETE api/<DoktorApiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var y1 = k.Kullanici.FirstOrDefault(s => s.KullaniciID == id);
            if (y1 == null)
            {
                return NotFound();
            }
            else
            {
                k.Remove(y1);
                k.SaveChanges();
                return Ok();
            }
        }
    }
}
