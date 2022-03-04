using Rehber.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rehber.Models.Context
{
    public class RehberContext : DbContext
    {
        public RehberContext() : base("Server=.;Database=Rehber;Trusted_Connection=true")
        {

        }
        public DbSet<Kisi> Kisiler { get; set; }
    
    }
}