using InvoiceManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataLibrary.BussinessLogic.PaymentProcessor;

namespace InvoiceManager.Controllers
{
    public class PaymentController : Controller
    {
        // GET: PaymentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PaymentController/Details/5
        public ActionResult Details(int id)
        {
            var data = LoadOnePayment(id);

            Models.PaymentModel payment = new Models.PaymentModel()
            {
                Id = data.Id,
                EmployeeId = data.EmployeeId,
                Value = data.Value,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
                Description = data.Description,
                Date = data.Date,
                EmployeeName = data.EmployeeName
            };

            return View(payment);
        }

        // GET: PaymentController/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.PaymentModel model)
        {            
            if (ModelState.IsValid)
            {
                int recordsCreated = CreatePayment(
                    model.EmployeeId,                    
                    model.Value,
                    model.Description,
                    model.Date
                    );

                return RedirectToAction("View");
            }
            return View();
        }

        // GET: PaymentController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = LoadOnePayment(id);

            Models.PaymentModel payment = new Models.PaymentModel()
            {
                Id = data.Id,
                EmployeeId = data.EmployeeId,
                Value = data.Value,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
                Description = data.Description,
                Date = data.Date,
                EmployeeName = data.EmployeeName
            };

            return View(payment);
        }

        // POST: PaymentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataLibrary.Models.PaymentModel model)
        {
            if(ModelState.IsValid)
            {
                EditPayment(model);

                return RedirectToAction("ViewPayments");
            }
            return RedirectToAction("ViewPayments");
        }

        // GET: PaymentController/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteOnePayment(id);

            return RedirectToAction("ViewPayments");
        }

        // POST: PaymentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ViewPayments()
        {
            var data = LoadPayments();

            List<PaymentModel> payments = new List<PaymentModel>();

            foreach (var row in data)
            {
                payments.Add(new PaymentModel
                {
                    Id = row.Id,
                    EmployeeId = row.EmployeeId,
                    Value = row.Value,
                    Date = row.Date,
                    Description = row.Description,
                    CreatedAt = row.CreatedAt,
                    UpdatedAt = row.UpdatedAt,
                    EmployeeName = row.EmployeeName
                });
            }

            return View(payments);
        }
    }
}
