﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Cities
{
    public class CityEditDto
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int CountryId { get; set; }
    }
}