using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ClientSearchWebAPI.Models
{
    public class ClientDbContext:DbContext
    {
         public ClientDbContext() : base("ClientDbContext")
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Client_Details> Client_Details { get; set; }
    }
}