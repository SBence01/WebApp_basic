﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Client.Models.ApiModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int ManNumber { get; set; }
        public int DepartmentId { get; set; }
    }
}
