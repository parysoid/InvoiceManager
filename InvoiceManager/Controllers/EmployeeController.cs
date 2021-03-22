using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataLibrary.BussinessLogic.EmployeeProcessor;

namespace InvoiceManager.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewEmployees()
        {
            var data = LoadEmployees();
            List<Models.EmployeeModel> employees = new List<Models.EmployeeModel>();

            foreach (var row in data)
            {
                employees.Add(new Models.EmployeeModel
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName
                });
            }

            return View(employees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {           
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.EmployeeModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateEmployee(
                    model.FirstName,
                    model.LastName
                    );

                return RedirectToAction("ViewEmployees");
            }
            return View();
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = LoadOneEmployee(id);

            Models.EmployeeModel employee = new Models.EmployeeModel()
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt
            };

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataLibrary.Models.EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                EditEmployee(model);

                return RedirectToAction("ViewEmployees");
            }
            return RedirectToAction("ViewEmployees");
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteOneEmployee(id);

            return RedirectToAction("ViewEmployees");
        }

        
    }
}
