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
            //lấy chương của kiến thức
            var chuong = db.DataAIs.Where(d => d.ID == id).FirstOrDefault().Chuong;
            //lấy ds tất cả các kiến thức nằm cùng chương với id 
            var lstKTLienQuan = db.DataAIs.Where(d => d.Chuong.Equals(chuong) && (d.ID != id)).ToList();
            var result = new List<DataAI>();
            //chỉ lấy 5 kiến thức đầu tiên
            if(lstKTLienQuan.Count > 5)
            {
                for(int i = 0; i < 5; i++)
                {
                    result.Add(lstKTLienQuan[i]);
                }
                ViewBag.lstKTLienQuan = result;
            }else
            {
                ViewBag.lstKTLienQuan = lstKTLienQuan;
            }
            

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

        public JsonResult SearchByNoiDung(string searchKey)
        {
            var result = db.DataAIs.Where(d => d.NoiDung.Contains(searchKey) || searchKey == null).ToList();
            var data = (from d in result
                        select new
                        {
                            ID = d.ID,
                            TieuDe = d.TieuDe,
                            NoiDung = d.NoiDung.Substring(0, 225) + " ..."
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchByKhaiNiem(string searchKey)
        {
            var result = db.DataAIs.Where(d => d.NoiDung.Contains(searchKey)
            && d.Loai.Equals("Khái niệm")
            || searchKey == null && d.Loai.Equals("Khái niệm")).ToList();
            var data = (from d in result
                        select new
                        {
                            ID = d.ID,
                            TieuDe = d.TieuDe,
                            NoiDung = d.NoiDung.Substring(0, 225) + " ..."
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchByDangBT(string searchKey)
        {
            var result = db.DataAIs.Where(d => d.NoiDung.Contains(searchKey)
            && d.Loai.Equals("Dạng bài tập")
            || searchKey == null && d.Loai.Equals("Dạng bài tập")).ToList();
            var data = (from d in result
                        select new
                        {
                            ID = d.ID,
                            TieuDe = d.TieuDe,
                            NoiDung = d.NoiDung.Substring(0, 225) + " ..."
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SearchByPhuongPhap(string searchKey)
        {
            var result = db.DataAIs.Where(d => d.NoiDung.Contains(searchKey)
            && d.Loai.Equals("Phương pháp")
            || searchKey == null && d.Loai.Equals("Phương pháp")).ToList();
            var data = (from d in result
                        select new
                        {
                            ID = d.ID,
                            TieuDe = d.TieuDe,
                            NoiDung = d.NoiDung.Substring(0, 225) + " ..."
                        }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}