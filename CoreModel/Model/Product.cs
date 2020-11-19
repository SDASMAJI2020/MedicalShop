using System;
using System.Collections.Generic;

namespace CoreModel.Model
{
    public partial class Product
    {
        public int Id { get; set; }
        public int Baseid { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public string Package { get; set; }
        public string Unit { get; set; }
        public decimal? Mrp { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxValue { get; set; }

        public virtual Base Base { get; set; }
    }
}
