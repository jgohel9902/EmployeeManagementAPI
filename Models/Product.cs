﻿namespace EmployeeProductAPI.Models
{
    public class Product
    {
        public int Id { get; set; }          // PK
        public string Name { get; set; } = "";
        public decimal Price { get; set; }   // use decimal for money
    }
}
