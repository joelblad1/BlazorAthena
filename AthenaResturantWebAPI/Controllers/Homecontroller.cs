using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AthenaResturantWebAPI.Controllers
{
    public class Homecontroller : Controller
    {
        // GET: Homecontroller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Homecontroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Homecontroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Homecontroller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: Homecontroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Homecontroller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Homecontroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Homecontroller/Delete/5
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
    }
}
