﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiquidWorld.Data.Models;

namespace LiquidWorld.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Drink> PreferredDrinks { get; set; }
    }
}
