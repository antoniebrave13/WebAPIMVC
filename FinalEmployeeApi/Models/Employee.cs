﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalEmployeeApi.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
    }
}