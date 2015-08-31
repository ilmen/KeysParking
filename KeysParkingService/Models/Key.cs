using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeysParkingService.Models
{
    public class Key
    {
        public int Id
        { get; set; }

        public string Login
        { get; set; }

        public string Password
        { get; set; }
    }
}