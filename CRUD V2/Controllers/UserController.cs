using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Mvc;
using CRUD_V2.Models;


namespace CRUD_V2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult GetData()
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    List<User> user = db.Users.ToList<User>();
                    return Json(new { data = user }, JsonRequestBehavior.AllowGet);
                }
            }catch (Exception)
            {
                throw new Exception("Can't Grab Data From Database");
            }
        }

        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {

            try
            {

                if (id == 0)
                    return View(new User());
                else
                {
                    using (DBModel db = new DBModel())
                    {
                        return View(db.Users.Where(x => x.UserID == id).FirstOrDefault<User>());
                    }
                }
            }catch(Exception)
            {
                throw new Exception("Couldn't get the  Data from Database");
            }
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(User user)
        {
            try
            {

                using (DBModel db = new DBModel())
                {
                    if (user.UserID == 0)
                    {
                        db.Employees.Add(user);
                        db.SaveChanges();
                        return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                    }
                }
            }catch(Exception)
            {
                throw new Exception("Can't Save and Update  to Database");
            }
        }



        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
            using (DBModel db = new DBModel())
            {
                User user = db.User.Where(x => x.UserID == id).FirstOrDefrault<User>();
                db.Employees.Remove(user);
                db.SaveChanges();
                return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
            }

            }catch (Exception)
            {
                throw new Exception("Can't Delete From Database");
            }
        }
    }
}