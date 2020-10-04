﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19_Chart.Model
{
    public class CountrySummary
    {
        public int Confirmed { get; set; }

        public DateTime Date { get; set; }
        public string ShortDate { get; set; }
    }
}