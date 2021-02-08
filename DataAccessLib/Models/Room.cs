using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLib.Models
{
    public class Room
    {
        public int Id { get; set; }

        public List<User> Users { get; set; } = new List<User>();
    }
}
