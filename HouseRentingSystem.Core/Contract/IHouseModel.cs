﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Core.Contract
{
    public interface IHouseModel
    {
        public string Title { get; set; }

        public string Address { get; set; }
    }
}
