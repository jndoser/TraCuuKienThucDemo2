using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TraCuuKienThucDemo2.Models;

namespace TraCuuKienThucDemo2.Controllers
{
    public class HomeController : Controller
    {
        KnowledgeDB db = new KnowledgeDB();
        public ActionResult Index(int id = 1)
        {
            var kienThuc = db.DataAIs.Where(d => d.ID == id).FirstOrDefault();
            return View(kienThuc);
        }

        public JsonResult ListMenu(string chuong)
        {
            var result = db.DataAIs.Where(d => d.Chuong.Equals(chuong)).ToList();
            var data = (from d in result
                        select new
                        {
                            ID = d.ID,
                            TieuDe = d.TieuDe
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}