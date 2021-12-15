using E_Ticaret.API.Data.Models;
using E_Ticaret.API.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace E_Ticaret.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        // GET api/<BasketController>/5
        [HttpGet(nameof(GetMyBasket))]
        public IActionResult GetMyBasket()
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<BasketModel>().GetAll().ToList();
                return Ok(Data);
            }
        }

        // POST api/<BasketController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BasketController>/5
        [HttpPut(nameof(UpdateItem))]
        public IActionResult UpdateItem(BasketModel basket)
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<BasketModel>().Get(basket.Id);
                Data.Price = basket.Price;
                Data.products = basket.products;
                uow.SaveChanges();
                return StatusCode(200, "Başarılı");
            }
        }

        // DELETE api/<BasketController>/5
        [HttpDelete(nameof(DeleteItem))]
        public IActionResult DeleteItem(int id)
        {
            using (var uow = new UnitOfWork())
            {
                var Data = uow.GetRepository<BasketModel>().Get(id);
                uow.GetRepository<BasketModel>().Delete(Data);
                uow.SaveChanges();
                return StatusCode(200, "Sepet Temizlendi");
            }
        }
    }
}
