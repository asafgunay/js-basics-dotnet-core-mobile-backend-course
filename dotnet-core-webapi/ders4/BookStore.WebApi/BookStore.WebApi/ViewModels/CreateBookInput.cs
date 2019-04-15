using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.WebApi.ViewModels
{
    public class CreateBookInput
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public decimal Rating { get; set; }
        public string Binding { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Details { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
    }
}
