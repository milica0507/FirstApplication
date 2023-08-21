using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aplikacija.Models
{
    public class User
    {
        public User()
        {
            UserId = Guid.NewGuid().ToString();
        }
        public string UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NumberPhone { get; set; }
        public string Username { get; set; }
        public string PasswordHash  { get; set; }
        public string PasswordSalt  { get; set; }
    }
}
