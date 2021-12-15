using E_Ticaret.API;
using E_Ticaret.API.Data.Data;
using E_Ticaret.API.Data.Models;
using E_Ticaret.API.DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet(nameof(GetUser))]
        public IActionResult GetUser([FromBody] int id)
        {
            UnitOfWork uow = new UnitOfWork();
            var Data = uow.GetRepository<UserModel>().Get(id);
            return Ok(Data);
        }
        [HttpPost(nameof(AddUser))]
        public IActionResult AddUser([FromBody] UserDto user)
        {
            UnitOfWork uow = new UnitOfWork();
            UserModel userModel = new UserModel
            {
                Mail = user.Mail,
                Password = user.Password,
                Username = user.Username
            };
            uow.GetRepository<UserModel>().Add(userModel);
            uow.SaveChanges();
            return Ok("Başarılı");
        }
        [HttpPost(nameof(UpdateUser))]
        public IActionResult UpdateUser([FromBody] UserModel user)
        {
            UnitOfWork uow = new UnitOfWork();
            var Data = uow.GetRepository<UserModel>().Get(user.Id);
            Data.Username = user.Username;
            Data.Mail = user.Mail;
            Data.Password = user.Password;
            uow.GetRepository<UserModel>().Update(Data);
            uow.SaveChanges();
            return Ok("Başarılı");
        }
        [HttpPost(nameof(DeleteUser))]
        public IActionResult DeleteUser([FromBody] UserModel user)
        {
            UnitOfWork uow = new UnitOfWork();
            var Data = uow.GetRepository<UserModel>().Get(user.Id);
            uow.GetRepository<UserModel>().Delete(Data);
            uow.SaveChanges();
            return Ok("Silindi");
        }
        [HttpGet(nameof(GetAll))]
        public List<UserModel> GetAll()
        {
            UnitOfWork uow = new UnitOfWork();
            var Data= uow.GetRepository<UserModel>().GetAll().ToList();
            return Data;
        }
    }
}
