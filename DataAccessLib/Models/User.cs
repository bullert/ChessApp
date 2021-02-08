using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string IsOnline { get; set; }
    }
}
