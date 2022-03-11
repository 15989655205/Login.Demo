using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Demo.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string  Account { get; set; }
        public string password { get; set; }
    }
}
