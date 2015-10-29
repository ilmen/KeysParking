using KPService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.IntegrityTests
{
    [TestFixture]
    public class KPDbContextTests
    {
        [Test]
        public void KeysFirstOrDefault_Always_ReturnsNotNull()
        {
            // TODO: настроить тестовое окружение
            var dbContext = KPDbContext.Instance;

            var key = dbContext.Keys.FirstOrDefault();

            Assert.IsNotNull(key);
        }

        [Test]
        public void KeyGroupsFirstOrDefault_Always_ReturnsNotNull()
        {
            // TODO: настроить тестовое окружение
            var dbContext = KPDbContext.Instance;

            var keyGroup = dbContext.KeyGroups.FirstOrDefault();

            Assert.IsNotNull(keyGroup);
        }
    }
}
