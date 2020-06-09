using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookSystemkendo.Controllers
{
    public class BookController : Controller
    {
        readonly Models.CodeService codeService = new Models.CodeService();
        readonly Models.LoginService loginservice = new Models.LoginService();
        readonly Models.BookService bookService = new Models.BookService();
        String user = "";
        // GET: Book
        public ActionResult Index(string User)
        {
            var user = TempData["user"] as string;
            ViewBag.user = user;
            return View("Index");
        }

        //新增圖書
        public ActionResult InsertBook()
        {
            var user = TempData["user"] as string;
            ViewBag.user = user;
            return View();
        }

        // 下拉選單
        [HttpPost]
        public JsonResult GetClassNameDropDownList()
        {
            return Json(this.codeService.GetBookClassName());
        }
        [HttpPost]
        public JsonResult GetUserNameDropDownList()
        {
            return Json(this.codeService.GetUserName());
        }
        [HttpPost]
        public JsonResult GetCodeNameDropDownList()
        {
            return Json(this.codeService.GetCodeName());
        }

        //kendoGrid
        [HttpPost]
        public JsonResult GetGridData(Models.BookSearchArg arg)
        {
            return Json(this.bookService.GetBookByCondtioin(arg));
        }

        //刪除資料
        [HttpPost]
        public JsonResult DeleteBook(int BookID)
        {
            try
            {
                bookService.DeleteBook(BookID);
                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }


        [HttpPost]
        public JsonResult InsertBook(Models.BookData book)
        {
            try
            {
                bookService.InsertBook(book);
                return this.Json(true);
            }
            catch (Exception ex)
            {
                return this.Json(false);
            }

        }
        [HttpPost]
        public JsonResult GetBookData(int BookID)
        {
            return Json(this.bookService.GetBookData(BookID));
        }
        public JsonResult LendBookRecord(int BookID)
        {
            return Json(this.bookService.GetBookLendRecord(BookID));
        }

        //登入
        public ActionResult LoginPage()
        {
            return View();
        }

        /// <summary>
        /// userlogin
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserLogin(Models.LoginData login)
        {
            loginservice.UserLogin(login);
            if (loginservice.UserLogin(login) != 0)
            {
                return this.Json(true);
            }
            else
            {
                return this.Json(false);
            }
        }

        /// <summary>
        ///  確認管理者登入
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Getifo(String User)
        {
            user = User;
            TempData["user"] = user;
            return this.Json(true);
        }

        [HttpPost]
        public JsonResult UpdateData(Models.BookData book)
        {
            bookService.UpdateBookData(book);
            return Json("");
        }
    }
}