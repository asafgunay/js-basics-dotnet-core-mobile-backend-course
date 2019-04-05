using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelVeritabani.ViewModels
{
    public class CreateSepetInput
    {
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    public class UpdateModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
    }
}
