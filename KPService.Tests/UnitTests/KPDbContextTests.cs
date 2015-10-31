using KPService.Models;
using NUnit.Framework;

namespace KPService.Tests.UnitTests
{
    public partial class UnitTests
    {
        [TestFixture]
        public class KPDbContextTests
        {
            [Test]
            public void Ctor_Default_UseDefaultConnectionStringProvider()
            {
                var db = new KPDbContext();
                var dcsp = new DefaultConnectionStringProvider();

                StringAssert.Contains(dcsp.ConnectionString, db.ReadOnlyConnectionString);
            }

            [Test]
            public void Ctor_Always_UseConnStrProviderParameter()
            {
                var tcsp = new TestConnectionStringProvider();
                var db = new KPDbContext(tcsp);

                StringAssert.Contains(tcsp.ConnectionString, db.ReadOnlyConnectionString);
            }
        }
    }
}