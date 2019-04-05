using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimi.Data.ViewModels
{
    public class CreateOgrenciInput
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int No { get; set; }
        public string Cinsiyet { get; set; }
        public int SinifId { get; set; }
    }
}
