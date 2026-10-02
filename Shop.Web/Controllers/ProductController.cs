using Shop.Web.Models;
using Shop.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Reflection;

namespace Shop.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            List<ProductDto>? list = new();
            ResponseDto? response = await _productService.GetAllProductsAsync();
            if (response != null && response.IsSuccess == true)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(list);
        }

        //public async Task<IActionResult> ProductCreate()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> ProductUpsert(ProductDto model)
        {
            ResponseDto? response = null;
            if (model.ProductId != null && model.ProductId != 0)
            {
                if (ModelState.IsValid)
                {
                    response = await _productService.UpdateProductsAsync(model);

                    if (response != null && response.IsSuccess == true)
                    {
                        TempData["success"] = "Product updated successfully";
                        return RedirectToAction(nameof(ProductIndex));
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                }
            }
            else
            {
                //model.ProductId = 0;
                if (ModelState.IsValid)
                {
                    response = await _productService.CreateProductsAsync(model);

                    if (response != null && response.IsSuccess == true)
                    {
                        TempData["success"] = "Product created successfully";
                        return RedirectToAction(nameof(ProductIndex));
                    }
                    else
                    {
                        TempData["error"] = response?.Message;
                    }
                }
            }
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductUpsert(int? productId)
        {
            ResponseDto? response = null;
            if (productId != null && productId != 0)
            {
                response = await _productService.GetProductByIdAsync(productId.Value);
                if (response != null && response.IsSuccess == true)
                {
                    ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                    return View(model);
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
                return NotFound();
            }
            else
            { 
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.UpdateProductsAsync(model);

                if (response != null && response.IsSuccess == true)
                {
                    TempData["success"] = "Product updated successfully";
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ProductDelete(int productId)
        {
            ResponseDto? response = await _productService.DeleteProductsAsync(productId);
            if (response != null && response.IsSuccess == true)
            {
                TempData["success"] = "Product deleted successfully";
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return RedirectToAction(nameof(ProductIndex));
        }
    }
}
