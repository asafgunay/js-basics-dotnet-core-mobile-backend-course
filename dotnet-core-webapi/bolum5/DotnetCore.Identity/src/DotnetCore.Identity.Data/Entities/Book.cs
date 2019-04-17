using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
        public decimal Rating { get; set; }
        public string Binding { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Details { get; set; }
        // publisher fk
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        public int PublisherId { get; set; }
        // author fk
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }

        public static Book Create(string name, decimal price, string imgUrl, decimal rating, string binding, DateTime releaseDate, string details, int publisherId, int authorId)
        {
            return new Book
            {
                AuthorId = authorId,
                Details = details,
                Binding = binding,
                ImgUrl = imgUrl,
                Name = name,
                Price = price,
                PublisherId = publisherId,
                Rating = rating,
                ReleaseDate = releaseDate
            };
        }

    }
}
