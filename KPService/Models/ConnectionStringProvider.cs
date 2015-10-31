using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPService.Models
{
    public class DefaultConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string connString = "defaultConnection";

        public string ConnectionString
        {
            get { return connString; }
        }
    }

    public class TestConnectionStringProvider : IConnectionStringProvider
    {
        private readonly string connString = "testConnection";

        public string ConnectionString
        {
            get { return connString; }
        }
    }
}