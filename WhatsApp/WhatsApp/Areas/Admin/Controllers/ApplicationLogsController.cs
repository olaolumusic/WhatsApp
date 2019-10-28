
using System.Web.Mvc;
using WhatsApp.Repository.Dao;
using WhatsApp.Repository.Interfaces;

namespace WhatsApp.Areas.Admin.Controllers
{
        public class ApplicationLogsController : Controller
        {
            private readonly IApplicationLogsRepository _applicationLogs;

            public ApplicationLogsController()
            {
                _applicationLogs = new ApplicationLogsRepository();
            }
            // GET: Admin/Admin
            public ActionResult Index()
        {
            var applicationLogs = _applicationLogs.FindAll();
            return View(applicationLogs);
        }

        // GET: Admin/Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Admin/Create
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

        // GET: Admin/Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Admin/Edit/5
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

        // GET: Admin/Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Admin/Delete/5
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
