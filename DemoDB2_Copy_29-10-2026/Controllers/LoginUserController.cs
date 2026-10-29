using System.Linq;
using System.Web.Mvc;
using DemoDB2.Models;

namespace DemoDB2.Controllers
{
    public class LoginUserController : Controller
    {
        private DBSportStoreEntities database = new DBSportStoreEntities();

        // GET: LoginUser/Index (Form Login)
        public ActionResult Index()
        {
            return View();
        }

        // POST: LoginUser/LoginAcount
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAcount(AdminUser _user)
        {
            var check = database.AdminUsers
                .Where(s => s.ID == _user.ID && s.PasswordUser == _user.PasswordUser)
                .FirstOrDefault();

            if (check == null) // Login thất bại
            {
                ViewBag.ErrorInfo = "Sai thông tin tài khoản hoặc mật khẩu!";
                return View("Index");
            }
            else // Login thành công
            {
                database.Configuration.ValidateOnSaveEnabled = false;
                Session["ID"] = _user.ID;
                Session["NameUser"] = check.NameUser;
                Session["PasswordUser"] = _user.PasswordUser;

                return RedirectToAction("Index", "Product");
            }
        }

        // GET: LoginUser/RegisterUser
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: LoginUser/RegisterUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser(AdminUser _user)
        {
            if (ModelState.IsValid)
            {
                var check_ID = database.AdminUsers.Where(s => s.ID == _user.ID).FirstOrDefault();
                if (check_ID == null) // Chưa tồn tại ID
                {
                    database.Configuration.ValidateOnSaveEnabled = false;
                    database.AdminUsers.Add(_user);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorRegister = "This ID is exist!";
                    return View();
                }
            }
            return View();
        }

        // Đăng xuất (Tùy chọn bổ sung)
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "LoginUser");
        }
    }
}