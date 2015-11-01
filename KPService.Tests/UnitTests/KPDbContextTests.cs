using KPService.Models;
using NSubstitute;
using NUnit.Framework;
using System;

namespace KPService.Tests.UnitTests
{
    public partial class UnitTests
    {
        [TestFixture]
        public class KPDbContextTests
        {
            [Test]
            public void Ctor_Default_UseNotEmptyAndNotNullConnectionString()
            {
                var db1 = new KPDbContext();

                StringAssert.AreNotEqualIgnoringCase(String.Empty, db1.ReadOnlyConnectionString);
                StringAssert.AreNotEqualIgnoringCase(null, db1.ReadOnlyConnectionString);
            }

            [Test]
            public void Ctor_Default_UseDefaultConnectionStringProvider()
            {
                var db1 = new KPDbContext();
                var db2 = new KPDbContext(new DefaultConnectionStringProvider());

                StringAssert.Contains(db1.ReadOnlyConnectionString, db2.ReadOnlyConnectionString);
            }

            [Test]
            public void Ctor_Always_UseConnStrProviderParameter()
            {
                var guarantedRandomString = Guid.NewGuid().ToString();
                var csp = Substitute.For<IConnectionStringProvider>();
                csp.ConnectionString.Returns(guarantedRandomString);

                var db = new KPDbContext(csp);

                StringAssert.Contains(guarantedRandomString, db.ReadOnlyConnectionString);
            }
        }
    }
}