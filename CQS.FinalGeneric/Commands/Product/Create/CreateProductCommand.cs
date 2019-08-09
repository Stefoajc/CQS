﻿using System;

namespace CQS.FinalGeneric.Commands.Product.Create
{
    public class CreateProductCommand
    {
        private Guid Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}