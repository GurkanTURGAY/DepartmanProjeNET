using Departman.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Departman.Controllers
{
    public class PersonelimController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Personels.Include(x => x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in c.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        public IActionResult YeniPersonel(Personel p)
        {
            var per = c.Birims.Where(x=>x.BirimID == p.Birim.BirimID).FirstOrDefault();
            p.Birim = per;
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
