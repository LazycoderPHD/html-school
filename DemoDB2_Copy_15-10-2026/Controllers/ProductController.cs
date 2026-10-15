using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class ProductController : Controller
    {
        //EntitiesDB database = new EntitiesDB();
        DBSportStoreEntities database = new DBSportStoreEntities();

        // GET: Product
        public ActionResult Index()
        {
            return View(database.Products.ToList());
        }

        // Action hiển thị DropDownList Category
        public ActionResult SelectCate()
        {
            Category se_cate = new Category();
            se_cate.ListCate = database.Categories.ToList();
            return PartialView(se_cate);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            Product pro = new Product();
            pro.ImagePro = "~/Content/images/add.png"; // Gán ảnh mặc định
            return View(pro);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product pro)
        {
            try
            {
                if (pro.UploadImage != null)
                {
                    string filename = Path.GetFileNameWithoutExtension(pro.UploadImage.FileName);
                    string extent = Path.GetExtension(pro.UploadImage.FileName);
                    filename = filename + extent;
                    pro.ImagePro = "~/Content/images/" + filename;
                    pro.UploadImage.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), filename));
                }
                database.Products.Add(pro);
                database.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pro);
            }
        }
    }
}