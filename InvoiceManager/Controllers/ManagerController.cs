using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using InvoiceManager.Models;
using static DataLibrary.BussinessLogic.InvoiceProcessor;
using InvoiceManager.Logic;
using Microsoft.Extensions.Options;
using System;
using DataLibrary.Models;

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
            return View();
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
                   
                return RedirectToAction("Create");   
            }
            return View();
        }

        // GET: ManagerController/Edit/5
        public ActionResult Edit(int id)
        {
            var data = LoadOneInvoice(id);

            Models.InvoiceModel invoices = new Models.InvoiceModel();

            foreach (var item in data)
            {
                invoices.Id = item.Id;
                invoices.InvoiceId = item.InvoiceId;
                invoices.Value = item.Value;
                invoices.Description = item.Description;
                invoices.CreatedAt = item.CreatedAt;
                    
            }

            return View(invoices);
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DataLibrary.Models.InvoiceModel model/*IFormCollection collection*/)
        {
            if(ModelState.IsValid)
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
    }
}
