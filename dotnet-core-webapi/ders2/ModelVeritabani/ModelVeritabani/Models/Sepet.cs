using Newtonsoft.Json;

namespace ModelVeritabani.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
