using KPService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Tests.UnitTests
{
    public partial class UnitTests
    {
        [TestFixture]
        public class DefaultConnectionStringProviderTests
        {
            [Test]
            public void ConnectionString_Always_ReturnsCorrectCSName()
            {
                var dcsp = new DefaultConnectionStringProvider();

                StringAssert.AreEqualIgnoringCase("DefaultConnection", dcsp.ConnectionString);
            }
        }

        [TestFixture]
        public class TestConnectionStringProviderTests
        {
            [Test]
            public void ConnectionString_Always_ReturnsCorrectCSName()
            {
                var dcsp = new TestConnectionStringProvider();

                StringAssert.AreEqualIgnoringCase("TestConnection", dcsp.ConnectionString);
            }
        }
    }
}
