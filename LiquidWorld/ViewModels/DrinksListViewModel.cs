using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquidWorld.Data.Models;

namespace LiquidWorld.ViewModels
{
    public class DrinksListViewModel
    {
        public IEnumerable<Drink> Drinks { get; set; }
        public int CurrentCategory { get; set; }
    }
}
