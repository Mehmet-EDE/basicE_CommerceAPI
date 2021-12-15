using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Ticaret.API.Data.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public int Count { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
    }
}
