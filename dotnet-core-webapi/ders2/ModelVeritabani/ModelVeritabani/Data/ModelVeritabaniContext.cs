using Microsoft.EntityFrameworkCore;
using ModelVeritabani.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelVeritabani.Data
{
    public class ModelVeritabaniContext : DbContext
    {
        public ModelVeritabaniContext(DbContextOptions<ModelVeritabaniContext> options) :base(options)
        {}

        public DbSet<Sepet> Sepets { get; set; }


    }
}
