using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using NimapProject.Models;

namespace NimapProject.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IConfiguration configuration;
        CategoryDAL db;
        public CategoryController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db = new CategoryDAL(configuration);
        }
        public IActionResult List()
        {
            var model = db.CategoryList();
            return View(model);
        }
        [HttpGet]

        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category c)
        {
            try
            {
                int res=db.AddCat(c);
                if(res==1)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpGet]

        public IActionResult EditCategory(int id)
        {
            var cat=db.GetCatById(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult EditCategory(Category c)
        {
            try
            {
                int res = db.UpdateCat(c);
                if (res == 1)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult DeleteCategory(int id)
        {
            var cat = db.GetCatById(id);
            return View(cat);
        }
        [HttpPost]
        [ActionName("DeleteCategory")]
        public IActionResult DeleteCategoryConfirm(int id)
        {
            try
            {
                int res = db.DeleteCategory(id);
                if (res == 1)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
