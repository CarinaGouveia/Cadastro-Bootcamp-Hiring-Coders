using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Hiring_Crud.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Pessoas> Pessoas { get; set; }

        public DbSet<Produtos> Produtos { get; set; }
    }
}