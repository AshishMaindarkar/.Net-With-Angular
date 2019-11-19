using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientSearchWebAPI.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String Dob { get; set; }
        public ICollection<Client_Details> Id { get; set; }
    }
}