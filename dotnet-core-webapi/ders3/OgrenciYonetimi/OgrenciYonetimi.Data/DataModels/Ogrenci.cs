using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OgrenciYonetimi.Data.DataModels
{
    [Table("Ogrenciler")]
    public class Ogrenci
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OgrenciId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int No { get; set; }
        public string Cinsiyet { get; set; }
        [ForeignKey("SinifId")]
        public virtual Sinif Sinif { get; set; }
        public int SinifId { get; set; }
    }
}
