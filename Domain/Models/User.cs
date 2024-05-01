using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set;}
        public int Age { get; set;}
        public string Gender { get; set;}
        public string Email { get; set;}
        public string PhoneNumber { get; set;}
        public string Country { get; set;}
        public string City { get; set;}
    }
}
