using Rehber.Models.Context;
using Rehber.Models.Entities;
using Rehber.Models.KisiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehber.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        RehberContext db = new RehberContext();
        public ActionResult Index()
        {
            var model = new KisiIndexViewModel
            {
                Kisiler = db.Kisiler.ToList()
             };
           
            return View(model);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Kisi kisi)
        {
            try
            {
                db.Kisiler.Add(kisi);
                db.SaveChanges();
                TempData["BasariliMesaj"] = "Ekleme İşleminiz Tamalanmıştır.";
            }
            catch (Exception)
            {

                TempData["HataliMesaj"] = "Hata Oluştu!";
            }
         
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi==null)
            {
                TempData["HataliMesaj"] = "Kayit Bulunamadi.";
                return RedirectToAction("Index");
            }
            var model = new KisiGucelleViewModel
            {
               Kisi=kisi
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Guncelle(Kisi kisi)
        {
            var eskikisi = db.Kisiler.Find(kisi.Id);
            if (eskikisi == null)
            {
                TempData["HataliMesaj"] = "Kayit Bulunamadi.";
                return RedirectToAction("Index");
            }

            eskikisi.Ad = kisi.Ad;
            eskikisi.Soyad = kisi.Soyad;
            eskikisi.CepTelefon = kisi.CepTelefon;
            eskikisi.EmailAdres = kisi.EmailAdres;
            eskikisi.Adres = kisi.Adres;
            db.SaveChanges();
            TempData["BasariliMesaj"] = "Kayıt Güncellendi";
            return RedirectToAction("Index");
          
        }
        [HttpGet]
        public ActionResult Detay(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kayit Bulunamadi.";
                return RedirectToAction("Index");
            }
            var model = new KisiDetayViewModel
            {
                Kisi = kisi
            };
            return View(model);
        }
        public ActionResult Sil(int id)
        {
            var kisi = db.Kisiler.Find(id);
            if (kisi == null)
            {
                TempData["HataliMesaj"] = "Kayit Bulunamadi.";
                return RedirectToAction("Index");
            }
            db.Kisiler.Remove(kisi);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}