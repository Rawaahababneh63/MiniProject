using MiniProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MiniProject.Controllers
{
    public class HomeController : Controller
    {
        public EcommerceEntities db = new EcommerceEntities();
        public ActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();

            
            Session["Categories"] = categories;

          
            return View(categories);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        //public ActionResult Category()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Category(Category category)
        //{
        //    using (  EcommerceEntities db = new EcommerceEntities())
        //    {
        //        db.Categories.Add(category);
        //       db.SaveChanges();
        //    }

        //    // تحديث الجلسة
        //    List<Category> categories = Session["Category"] as List<Category> ?? new List<Category>();
        //    categories.Add(category);
        //    Session["Category"] = categories;

        //    return RedirectToAction("Index");
        //}
        //public ActionResult DeleteCategory()
        //{
        //    List<Category> categories = Session["Category"] as List<Category>;
        //    return View(categories);
        //}
        //public ActionResult Delete(int id)
        //{
        //    var category = db.Categories.Find(id);  // البحث عن القسم بناءً على المعرف (ID)
        //    if (category == null)
        //    {
        //        return HttpNotFound();  // إذا لم يتم العثور على القسم، يعرض صفحة خطأ
        //    }
        //    return View(category);  // تمرير بيانات القسم إلى العرض
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    var category = db.Categories.Find(id);  // البحث عن القسم بناءً على المعرف (ID)
        //    if (category != null)
        //    {
        //        db.Categories.Remove(category);  // حذف القسم من قاعدة البيانات
        //        db.SaveChanges();  // حفظ التغييرات في قاعدة البيانات
        //    }
        //    return RedirectToAction("Index");  // العودة إلى صفحة قائمة الأقسام بعد الحذف
        //}

















    }
}