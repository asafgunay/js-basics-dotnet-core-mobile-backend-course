using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OgrenciYonetimi.Data.DataModels
{
    [Table("Dersler")]
    public class Ders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DersId { get; set; }
        public string DersAdi { get; set; }
        [ForeignKey("SinifId")]
        public virtual Sinif Sinif { get; set; }
        public int SinifId { get; set; }
        public DateTime CreatedDate { get; set; }
        public static Ders Create(string dersAdi, int sinifId)
        {
            return new Ders
            {
                DersAdi = dersAdi,
                SinifId = sinifId,
                CreatedDate=DateTime.Now
            };
        }
    }
}
