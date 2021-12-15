using E_Ticaret.API.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using E_Ticaret.API;
using E_Ticaret.API.Data.Data;
using E_Ticaret.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpGet(nameof(Getproduct))]
        public IActionResult Getproduct([FromBody] int id)
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<ProductModel>().Get(id);
                return Ok(Data);
            }
        }
        [HttpGet(nameof(GetProductAll))]
        public IActionResult GetProductAll()
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<ProductModel>().GetAll().ToList();
                return Ok(Data);
            }
        }
        [HttpPost(nameof(AddProduct))]
        public IActionResult AddProduct([FromBody] ProductModel product)
        {
            using (var uow = new UnitOfWork())
            {
                ProductModel productmodel = new ProductModel
                {
                    ProductName = product.ProductName,
                    Price = product.Price,
                    Count = product.Count,
                    Text = product.Text,
                    Photo = product.Photo,
                };
                uow.GetRepository<ProductModel>().Add(productmodel);
                if (uow.SaveChanges() > 0)
                    return StatusCode(201, productmodel);
                return StatusCode(500);
            }
        }
        [HttpPost(nameof(UpdateProduct))]
        public IActionResult UpdateProduct([FromBody] ProductModel product)
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<ProductModel>().Get(product.Id);
                Data.ProductName = product.ProductName;
                Data.Price = product.Price;
                Data.Count = product.Count;
                Data.Text = product.Text;
                Data.Photo = product.Photo;
                uow.SaveChanges();
                return StatusCode(200, "Güncelleme Başarılı");
            }
        }
        [HttpPost(nameof(DeleteProduct))]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<ProductModel>().Get(id);
                uow.GetRepository<ProductModel>().Delete(Data);
                uow.SaveChanges();
                return StatusCode(200, "Silindi");
            }
        }
    }
}
