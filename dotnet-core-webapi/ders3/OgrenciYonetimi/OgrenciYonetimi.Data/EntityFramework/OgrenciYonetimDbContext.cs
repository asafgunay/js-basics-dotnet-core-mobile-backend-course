using Microsoft.EntityFrameworkCore;
using OgrenciYonetimi.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OgrenciYonetimi.Data.EntityFramework
{
    // Entity Framework ile veritabanını yönetecek sınıfı oluşturuyoruz
    public class OgrenciYonetimDbContext:DbContext //EntityFramework'ün Context yapısını oluşturduğumuz sınıfa katıyoruz.
    {
        // Yapıcı metod sayesinde sınıf tanımlandığında ilk yapılacak işleri tanımlıyoruz.
        // Bu sınıf veritabanını yöneteceği için ilk yapacağı iş entity framework ile bağlantısını yapıcı metod vasıtası ile kurmak.
        // Bu kurulan ilişkinin tek eksiği veritabanının adı ve adresi.
        // Bu eksiklik Startup.cs dosyasında tamamlanacak.
        public OgrenciYonetimDbContext(DbContextOptions<OgrenciYonetimDbContext> options):base(options)
        {
        }
        // DbSet'ler buraya gelecek
        // Ve bu sayede oluşturduğumuz sınıflar
        // Veritabanı tablolarına dönüşecek!!

        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<Ogrenci> Ogrenciler { get; set; }

        
    }
}
