using CrudcoreWithMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudcoreWithMVC.Controllers
{
    public class HomeController : Controller
    {
        //Create Constructor - Sort ctor
        private readonly StudentDbContext studentDb;
        public HomeController(StudentDbContext studentDb)
        {
            this.studentDb = studentDb;
        }

        //Fetch Data In Database 
        public async Task<IActionResult> Index()
        {
             var stdData = await studentDb.Students.ToListAsync();
            return View(stdData);
        }

        //Create Data in Database.
        public IActionResult Create()
        {
            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value="Male", Text="Male"},
                new SelectListItem {Value="Female", Text="Female"},
            };
            ViewBag.Gender = Gender;
            return View();
        }

        //Insert Data in Database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student std)
        {
            if (ModelState.IsValid)
            {
                //insert data in database 
                await studentDb.Students.AddAsync(std);
                await studentDb.SaveChangesAsync();
                TempData["Insert_Success"] = "Insert Data SuccessFully";
                //Redirect To Home Page
                return RedirectToAction("Index","Home");
            }
            return View(std);
        }

        //Details Views 
        public async Task<IActionResult> Details(int? id)
        {
            if (id==null || studentDb.Students==null)
            {
                return NotFound();
            }
            var stdData = await studentDb.Students.FirstOrDefaultAsync(x => x.id == id);

            if (stdData==null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        //Edit Data In Database Fetch and Display Input Box
        public async Task<IActionResult> Edit(int? id)
        {

            List<SelectListItem> Gender = new()
            {
                new SelectListItem {Value="Male", Text="Male"},
                new SelectListItem {Value="Female", Text="Female"},
            };
            ViewBag.Gender = Gender;
            if (id == null || studentDb.Students == null)
            {
                return NotFound();
            }
            var stdData = await studentDb.Students.FindAsync(id);
            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }

        //Edit Data In Database 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Student std)
        {
            if (id!=std.id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                 studentDb.Students.Update(std);   //Update data in database 
                //studentDb.Update(std);   //Sort Method Update 
                await studentDb.SaveChangesAsync();
                TempData["Update_Success"] = "Update Data SuccessFully";
                //Redirect To Home Page
                return RedirectToAction("Index", "Home");
            }
            
            return View(std);
        }


        //Delete Data in Database.
        public async Task<IActionResult>Delete(int? id)
        {
            if (id==null|| studentDb.Students==null)
            {
                return NotFound();
            }
            var stdData=await studentDb.Students.FirstOrDefaultAsync(x=>x.id==id);

            if (stdData == null)
            {
                return NotFound();
            }
            return View(stdData);
        }


        //Delete Data in Database id Wise.

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var stdData = await studentDb.Students.FindAsync(id);
            if (stdData != null)
            {
                studentDb.Students.Remove(stdData);  //Delete data in database 
            }
            await studentDb.SaveChangesAsync();
            TempData["Delete_Success"] = "Delete Data SuccessFully";
            return RedirectToAction("Index", "Home"); //Redirect To Home Page
        }


        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

