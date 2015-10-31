using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPService.Models
{
    public class DefaultConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string connString = "defaultConnnection";

        public string ConnectionString
        {
            get { return connString; }
        }
    }
}