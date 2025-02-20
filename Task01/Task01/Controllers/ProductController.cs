using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Task01.Models;

namespace Task01.Controllers
{
    public class ProductController : Controller
    {
        ProductBL productBL = new ProductBL();
        public IActionResult All()
        {
          //as model
          List<Product> ProductsModel=productBL.GetAll();
            //send data to view
            return View("ShowAll",ProductsModel );//list of product
        }

        //Details
        //endpoint /Product/Details/1 | /product/Details?id=1

        public IActionResult Details(int id)
        {
            Product ProModel = productBL.GetById(id);
            return View("Details", ProModel); // view Details , Model with type student
        }

    }
}
