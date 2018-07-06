using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sample.Controllers
{
    public class MyController : Controller
    {
        MyDB db = new MyDB();
        // GET: My
        public ActionResult Index()
        {           
            return View();
        }
        public JsonResult getdata()
        {
            var data = db.Employee.Select(a=> new {a.Empid,a.Empname,a.Empaddress,a.Empsalary,a.Empemail,a.Empdateofbirth, a.DesignId, a.Designation.DesignationName}).ToList();
            return Json(data,JsonRequestBehavior.AllowGet);
        }
        public JsonResult InsertEmployee(Jn_Employee e)
        {
            if (e.Empid==0)
            {
                db.Employee.Add(e);
                db.SaveChanges();
                return Json("Insert Successful", JsonRequestBehavior.AllowGet);
            }
            //for update
            else
            {
                var data = db.Employee.Where(d=> d.Empid== e.Empid).FirstOrDefault();
                data.Empname = e.Empname;
                data.Empaddress = e.Empaddress;
                data.Empsalary = e.Empsalary;
                data.Empemail = e.Empemail;
                data.Empdateofbirth = e.Empdateofbirth;
                data.DesignId = e.DesignId;
                db.SaveChanges();
                return Json("Update Successfull", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteEmployee(int id)
        {
            var data = db.Employee.Where(d => d.Empid == id).FirstOrDefault();
            db.Employee.Remove(data);
            db.SaveChanges();
            return Json("Delete Successful", JsonRequestBehavior.AllowGet);
        }
        public JsonResult getDesignation()
        {
            var result = db.employeeDesig.Select(s=> new {s.DesignId,s.DesignationName }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

#region Zin
        public ActionResult Bank()
        {
            return View();
        }

        public JsonResult getData()
        {
            var data = db.bank.Select(a => new { a.BankId, a.BankName, a.BankCode }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult insertBank (Bank b)
        {
            if (b.BankId==0)
            {
                db.bank.Add(b);
                db.SaveChanges();
                return Json("Insert Successful", JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = db.bank.Where(d => d.BankId == b.BankId).FirstOrDefault();
                data.BankName = b.BankName;
                data.BankCode = b.BankCode;
                db.SaveChanges();
                return Json("Update Successfull", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult deleteBank(int id)
        {
            var data = db.bank.Where(d => d.BankId == id).FirstOrDefault();
            db.bank.Remove(data);
            db.SaveChanges();
            return Json("Delete Successful", JsonRequestBehavior.AllowGet);
        }

#endregion

        public ActionResult Branch()
        {
            return View();
        }

        public JsonResult getBank()
        {
            var result = db.bank.Select(s => new { s.BankId, s.BankName }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getBranchdata()
        {
            
            var data = db.branch.Select(a => new { a.BranchId, a.BranchName, a.SwiftCode, a.BankId, a.Bank.BankName }).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult insertBranch(Branch e)
        {
            if (e.BranchId == 0)
            {
                db.branch.Add(e);
                db.SaveChanges();
                return Json("Insert Successful", JsonRequestBehavior.AllowGet);
            }
            //for update
            else
            {
                var data = db.branch.Where(d => d.BranchId == e.BranchId).FirstOrDefault();
                data.BranchName = e.BranchName;
                data.SwiftCode = e.SwiftCode;
                data.BankId = e.BankId;
                db.SaveChanges();
                return Json("Update Successfull", JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult deleteBranch(int id)
        {
            var data = db.branch.Where(d => d.BranchId == id).FirstOrDefault();
            db.branch.Remove(data);
            db.SaveChanges();
            return Json("Delete Successful", JsonRequestBehavior.AllowGet);
        }
    }
}