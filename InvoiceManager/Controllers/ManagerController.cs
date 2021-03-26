using InvoiceManager.Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static DataLibrary.BussinessLogic.InvoiceProcessor;

namespace InvoiceManager.Controllers
{
    public class ManagerController : Controller
    {
        // GET: ManagerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ManagerController/Details/5
        public ActionResult Details(int id)
        {
            var data = LoadOneInvoice(id);

            Models.InvoiceModel invoice = new Models.InvoiceModel()
            {
                Id = data.Id,
                InvoiceId = data.InvoiceId,
                Description = data.Description,
                Value = data.Value,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
                Date = data.Date
            };

            return View(invoice);
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.InvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateInvoice(
                    model.Description,
                    model.Value,
                    model.Date
                    );

                return RedirectToAction("ViewInvoices");
            }
            return View();
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = LoadOneInvoice(id);

            Models.InvoiceModel invoice = new Models.InvoiceModel()
            {
                Id = data.Id,
                InvoiceId = data.InvoiceId,
                Description = data.Description,
                Value = data.Value,
                CreatedAt = data.CreatedAt,
                UpdatedAt = data.UpdatedAt,
                Date = data.Date
            };

            return View(invoice);
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataLibrary.Models.InvoiceModel model/*IFormCollection collection*/)
        {
            if (ModelState.IsValid)
            {
                EditInvoice(model);

                return RedirectToAction("ViewInvoices");
            }
            return RedirectToAction("ViewInvoices");
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            DeleteOneInvoice(id);

            return RedirectToAction("ViewInvoices");
            //return View();
        }

        // POST: ManagerController/Delete/5
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

        public ActionResult ViewInvoices()
        {
            var data = LoadInvoices();
            List<Models.InvoiceModel> invoices = new List<Models.InvoiceModel>();

            foreach (var row in data)
            {
                invoices.Add(new Models.InvoiceModel
                {
                    Id = row.Id,
                    InvoiceId = row.InvoiceId,
                    Description = row.Description,
                    CreatedAt = row.CreatedAt,
                    UpdatedAt = row.UpdatedAt,
                    Value = row.Value,
                    Date = row.Date
                });
            }

            return View(invoices);
        }

        // GET: ManagerController/ViewMonth/0
        [HttpGet]
        [Route("Manager/ViewMonth/{month:int?}")]
        public ActionResult ViewMonth(int month = 0)
        {
            var dates = DateAndTime.GetMonthStartEnd2(month);

            var data = LoadMonth(dates[0], dates[1]);

            List<Models.InvoiceModel> invoices = new List<Models.InvoiceModel>();

            foreach (var row in data)
            {
                invoices.Add(new Models.InvoiceModel
                {
                    Id = row.Id,
                    InvoiceId = row.InvoiceId,
                    Description = row.Description,
                    CreatedAt = row.CreatedAt,
                    UpdatedAt = row.UpdatedAt,
                    Value = row.Value,
                    Date = row.Date
                });
            }



            return View(invoices);
        }
    }
}
