using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiquidWorld.Data.Models
{
    public class ShoppingCartItem
    {
        public string Drink { get; set; }
        public int Amount { get; set; }
        public int ShoppingCartItemId { get; set; }
        public decimal price { get; set; }
    }
}
