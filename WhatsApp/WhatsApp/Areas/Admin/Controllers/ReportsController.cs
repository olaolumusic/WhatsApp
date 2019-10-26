
using System.Web.Mvc;
using WhatsApp.Repository.Dao;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Areas.Admin.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IReportsRepository _reports;

        public ReportsController()
        {
            _reports = new ReportsRepository();
        }

        // GET: Admin/Reports
        public ActionResult Index()
        {
            var reports = _reports.FindAll();

            return View(reports);           
        }

        // GET: Admin/Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Reports/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Reports/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Reports/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Reports/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Reports/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Reports/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
