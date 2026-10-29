using System.Linq;
using System.Web.Mvc;
using DemoDB2.Models; // Namespace chứa các Entity model của bạn
using System.Net;
using System.Data.Entity;

//DaoNguyenPhat

namespace DemoDB2.Controllers
{
    public class CategoriesController : Controller
    {
        DBSportStoreEntities database = new DBSportStoreEntities();

        public ActionResult Index(string _name)
        {
            if (string.IsNullOrEmpty(_name))
            {
                var categories = database.Categories.OrderByDescending(c => c.Id).ToList();
                return View(categories);
            }
            else
            {
                var categories = database.Categories
                                         .Where(c => c.NameCate.Contains(_name))
                                         .OrderByDescending(c => c.Id)
                                         .ToList();
                return View(categories);
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    database.Categories.Add(category);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Lỗi khi thêm mới danh mục.");
            }
            return View(category);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = database.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = database.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    database.Entry(category).State = EntityState.Modified;
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ModelState.AddModelError("", "Lỗi khi cập nhật danh mục.");
            }
            return View(category);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = database.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Category category = database.Categories.Find(id);
            database.Categories.Remove(category);
            database.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}