using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Controllers
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public byte role { get; set; }
    }
}
