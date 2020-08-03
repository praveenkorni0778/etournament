using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using etournament.Models;
using PagedList;

namespace etournament.Controllers
{
    public class UserController : Controller
    {
        dbetournamentEntities db = new dbetournamentEntities();
        // GET: User
        public ActionResult Index(int ? page)
        {
            int pagesize = 9, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_category.Where(x => x.c_status == 1).OrderByDescending(x => x.c_id).ToList();
            IPagedList<tbl_category> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
            
        }

        
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(tbl_user uvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {
                tbl_user usr = new tbl_user();
                usr.u_name = uvm.u_name;
                usr.u_img = path;  
                usr.u_email = uvm.u_email;
                usr.u_password = uvm.u_password;
                usr.u_dob = uvm.u_dob;
                usr.u_age = uvm.u_age;
                usr.u_contact = uvm.u_contact;
                usr.u_gender = uvm.u_gender;
                usr.u_desc = uvm.u_desc;
                db.tbl_user.Add(usr);
                db.SaveChanges();

                return RedirectToAction("UserLogin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            Session["u_id"] = null;
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session["u_id"] = null;
            Session.Abandon();
            return RedirectToAction("UserLogin","User");
        }

        [HttpPost]
        public ActionResult UserLogin(tbl_user avm)
        {
            tbl_user ad = db.tbl_user.Where(x => x.u_email == avm.u_email && x.u_password == avm.u_password).SingleOrDefault();
            if (ad != null)
            {
                Session["u_id"] = ad.u_id.ToString();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.error = "invalid username or password";
            }
            return View("UserLogin");
        }
        [HttpGet]
        public ActionResult CreatePost()
        {
            if (Session["u_id"] != null)
            {
                List<tbl_category> li = db.tbl_category.ToList();
                ViewBag.categorylist = new SelectList(li, "c_id", "c_name");
                return View();
            }
            else
            {
                Response.Redirect("Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(tbl_tournament tvm, HttpPostedFileBase imgfile)
        {
            string path = uploadimgfile(imgfile);
            if (path.Equals("-1"))
            {
                ViewBag.error = "Image could not be uploaded";
            }
            else
            {

                tbl_tournament t = new tbl_tournament();
                t.t_name = tvm.t_name;
                t.t_image = path;
                t.t_add = tvm.t_add;
                t.t_website = tvm.t_website;
                t.t_dts = tvm.t_dts;
                t.t_dte = tvm.t_dte;
                t.t_contact =  tvm.t_contact;
                t.t_cat = tvm.t_cat;
                t.t_fk = Convert.ToInt32(Session["u_id"].ToString());
                t.t_desc = tvm.t_desc;
                t.t_entryfee = tvm.t_entryfee;
                t.t_prize = tvm.t_prize;
                t.t_location = tvm.t_location;
                db.tbl_tournament.Add(t);
                db.SaveChanges();
                Response.Redirect("Index");
            }
            return View();
        }

        public ActionResult Viewall(int ? page)
        {
            int pagesize = 12, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_tournament.OrderByDescending(x => x.t_dts).ToList();
            IPagedList<tbl_tournament> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
        }

        public ActionResult Contests(int ? id , int ? page)
        {
            int pagesize = 12, pageindex = 1;
            pageindex = page.HasValue ? Convert.ToInt32(page) : 1;
            var list = db.tbl_tournament.Where(x => x.t_cat == id).OrderByDescending(x => x.t_dts).ToList();
            IPagedList<tbl_tournament> stu = list.ToPagedList(pageindex, pagesize);
            return View(stu);
            
        }

        public ActionResult DeleteT(int? id)
        {
            tbl_tournament t = db.tbl_tournament.Where(x => x.t_id == id).SingleOrDefault();
            db.tbl_tournament.Remove(t);
            db.SaveChanges();
            return View("Home");
        }

        public ActionResult Viewcontest(int? id )
        {
            Addmodel ad = new Addmodel();
            tbl_tournament t = db.tbl_tournament.Where(x => x.t_id == id).SingleOrDefault();
            ad.t_id = t.t_id;
            ad.t_name = t.t_name;
            ad.t_image= t.t_image;
            ad.t_website = t.t_website;
            ad.t_add = t.t_add;
            ad.t_contact = t.t_contact;
            ad.t_dts = t.t_dts;
            ad.t_dte = t.t_dte;
            ad.t_cat = t.t_cat;
            ad.t_fk = t.t_fk;
            ad.t_prize = t.t_prize;
            ad.t_desc = t.t_desc;
            ad.t_location = t.t_location;
            ad.t_entryfee = t.t_entryfee;
            tbl_category cat = db.tbl_category.Where(x => x.c_id == t.t_cat).SingleOrDefault();
            ad.c_name = cat.c_name;
            tbl_user user = db.tbl_user.Where(x => x.u_id == t.t_fk).SingleOrDefault();
            ad.u_name = user.u_name;
            ad.u_img = user.u_img;
            ad.u_desc = user.u_desc;
            ad.u_email = user.u_email;
            ad.t_fk = user.u_id;
            return View(ad);
        }

        public string uploadimgfile(HttpPostedFileBase file)
        {
            Random r = new Random();
            string path = "-1";
            int random = r.Next();
            if (file != null && file.ContentLength > 0)
            {
                string extension = Path.GetExtension(file.FileName);
                if (extension.ToLower().Equals(".jpg") || extension.ToLower().Equals(".jpeg") || extension.ToLower().Equals(".png"))
                {
                    try
                    {
                        path = Path.Combine(Server.MapPath("~/Content/upload"), random + Path.GetFileName(file.FileName));
                        file.SaveAs(path);
                        path = "~/Content/upload/" + random + Path.GetFileName(file.FileName);

                    }
                    catch (Exception ex)
                    {
                        path = "-1";
                    }
                }
                else
                {
                    Response.Write("<script>alert('Only .jpg, .png, and .jpeg formats are acceptable...');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Please select a file');</script>");
                path = "-1";
            }
            return path;
        }
    }
}