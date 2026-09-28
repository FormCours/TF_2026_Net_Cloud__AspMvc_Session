using Demo_ASPMVC_Session.Domain.Models;
using Demo_ASPMVC_Session.Domain.Services;
using Demo_ASPMVC_Session.Mappers;
using Demo_ASPMVC_Session.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Demo_ASPMVC_Session.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Affichage de la liste des produits
            IEnumerable<Product> products = _productService.GetAll();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Affichage du formulaire
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductFormModel model)
        {
            // Traitement des données du formulaires
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _productService.Create(model.ToProduct());
            //_productService.Create(ProductMapper.ToProduct(model));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Affichage d'une page de confirmation
            Product product = _productService.GetById(id);
            return View(product);
        }

        [HttpGet]
        [Route("product/delete/{id}/confirm")]
        public IActionResult DeleteConfirm(int id)
        {
            // Suppression de l'element
            _productService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
