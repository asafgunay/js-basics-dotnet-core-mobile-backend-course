using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OgrenciYonetimi.Data.DataModels
{
    public class OgrenciDers
    {
        public int Id { get; set; }

        [ForeignKey("DersId")]
        public virtual Ders Ders { get; set; }
        public int? DersId { get; set; }

        [ForeignKey("OgrenciId")]
        public virtual Ogrenci Ogrenci { get; set; }
        public int? OgrenciId { get; set; }

        public static OgrenciDers Create(int dersId, int ogrenciId)
        {
            return new OgrenciDers
            {
                DersId = dersId,
                OgrenciId = ogrenciId
            };
        }
    }
}
