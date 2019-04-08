using OgrenciYonetimi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimi.Data.ViewModels
{
    public class OgrenciDersleri
    {
        public Ogrenci Ogrenci { get; set; }
        public List<Ders> OgrencininDersleri { get; set; }
    }
}
