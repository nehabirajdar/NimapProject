using Microsoft.AspNetCore.Mvc;
using NimapProject.Models;

namespace NimapProject.Controllers
{
    public class ProductController : Controller
    {

        private readonly IConfiguration configuration;
        ProductDAL db;
        public ProductController(IConfiguration configuration)
        {
            this.configuration = configuration;
            db= new ProductDAL(configuration);
        }
        public IActionResult List()
        {
            var model=db.ProductList();
            return View(model);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            try
            {
                int res=db.AddProd(p);
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

        public IActionResult EditProduct(int id)
        {
            var cat = db.GetProdById(id);
            return View(cat);
        }
        [HttpPost]
        public IActionResult EditProduct(Product p)
        {
            try
            {
                int res=db.UpdateProd(p);
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
        public IActionResult DeleteProduct(int id)
        {
            var cat=db.GetProdById(id);
            return View(cat);
        }
        [HttpPost]
        [ActionName("DeleteProduct")]
        public IActionResult DeleteProductConfirm(int id)
        {
            try
            {
                int res = db.DeleteProduct(id);
                if (res==1)
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
