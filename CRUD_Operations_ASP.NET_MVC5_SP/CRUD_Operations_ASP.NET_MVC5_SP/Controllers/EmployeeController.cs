using System.Web.Mvc;
using CRUD_Operations.Repositories;
using CRUD_Operations.Models;

namespace CRUD_Operations.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeRepository CRUDEmployee;

        // GET: Employee/SearchEmployee
        [HttpGet()]
        public ActionResult SearchEmployee()
        {
            CRUDEmployee = new EmployeeRepository();
            ModelState.Clear();

        return View(CRUDEmployee.SearchEmployee());
        }

        // GET: Employee/RegisterEmployee
        [HttpGet()]
        public ActionResult RegisterEmployee()
        {

        return View();
        }

        // POST: Employee/RegisterEmployee
        [HttpPost()]
        public ActionResult RegisterEmployee(EmployeeModel EmployeeData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CRUDEmployee = new EmployeeRepository();

                    if(CRUDEmployee.RegisterEmployee(EmployeeData) >= 1)
                    {
                        ViewBag.Message = "Empleado registrado";
                        ModelState.Clear();
                    }
                }

            return View();
            }
            catch
            {

            return View();
            }
        }

        // GET: Employee/DetailEmployee
        [HttpGet()]
        public ActionResult DetailEmployee(int IdEmployee)
        {
            CRUDEmployee = new EmployeeRepository();
            ModelState.Clear();

        return View(CRUDEmployee.SearchEmployee().Find(Employee => Employee.IdEmployee == IdEmployee));
        }

        // GET: Employee/UpdateEmployee
        [HttpGet()]
        public ActionResult UpdateEmployee(int IdEmployee)
        {
            CRUDEmployee = new EmployeeRepository();
            ModelState.Clear();

        return View(CRUDEmployee.SearchEmployee().Find(Employee => Employee.IdEmployee == IdEmployee));
        }

        // POST: Employee/UpdateEmployee
        [HttpPost()]
        public ActionResult UpdateEmployee(EmployeeModel EmployeeData, int IdEmployee)
        {
            try
            {
                CRUDEmployee = new EmployeeRepository();
                CRUDEmployee.UpdateEmployee(EmployeeData);

            return RedirectToAction("SearchEmployee", "Employee");
            }
            catch
            {

            return View();
            }
        }

        // GET: Employee/DeleteEmployee
        [HttpGet()]
        public ActionResult DeleteEmployee(int IdEmployee)
        {
            try
            {
                CRUDEmployee = new EmployeeRepository();

                if(CRUDEmployee.DeleteEmployee(IdEmployee) >= 1)
                {
                    ViewBag.AlertMsg = "Empleado eliminado";
                }

            return RedirectToAction("SearchEmployee", "Employee");
            }
            catch
            {

            return View();
            }
        }
    }
}