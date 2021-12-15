using System;
using System.Collections.Generic;
using System.Text;

namespace E_Ticaret.API.Data.Models
{
    class BasketModel
    {
        public int Id { get; set; }
        public List<ProductModel> products { get; set; }
        public float Price { get; set; }
    }
}
