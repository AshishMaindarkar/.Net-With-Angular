using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientSearchWebAPI.Models
{
    public class Client_Details
    {

        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public Client client { get; set; }
    }
}