using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD_LAB11.Repository;
using CRUD_LAB11.Models;

namespace CRUD_LAB11.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository repository = new EmpRepository();
            ModelState.Clear();
            return View(repository.GetEmployees());
        }
        //ADD: Employee
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpRepository repo = new EmpRepository();
                    if (repo.AddEmployee(emp))
                    {
                        ViewBag.message = "Almacenado Correctamente";
                    }
                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch (Exception)
            {
                return View();
            }
        }

        public ActionResult EditEmployee(int id)
        {
            EmpRepository repo = new EmpRepository();
            return View(repo.GetEmployees().Find(Emp=>Emp.id==id));
        }
        [HttpPost]
        public ActionResult EditEmployee(Employee obj)
        {
            try
            {
                EmpRepository repo = new EmpRepository();
                repo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmpDetails");
            }
            catch(Exception)
            {
                return View();
            }
        }

        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository repo = new EmpRepository();
                if (repo.DeleteEmployee(id))
                {
                    ViewBag.AlerMsg = "Empleado Eliminado";
                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch (Exception)
            {
                return View();
            }
        }
            
    }
}