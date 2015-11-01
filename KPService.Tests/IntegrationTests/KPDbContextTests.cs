using KPLibrary;
using KPService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Tests.IntegrationTests
{
    public partial class IntegrationTests
    {
        [TestFixture]
        public class KPDbContextTests
        {
            #region Helpers
            private KPDbContext GetTestDbContext()
            {
                var tcsp = new TestConnectionStringProvider();
                return new KPDbContext(tcsp);
            }
            #endregion

            [Test]
            public void KeysDbSet_Always_ReturnsNotEmptyCollection()
            {
                var db = GetTestDbContext();

                var keysCount = db.Keys.Count<Key>();

                Assert.Greater(keysCount, 0);
            }

            [Test]
            public void KeysDbSet_Always_ReturnsKeyClassInstanceCollection()
            {
                var db = GetTestDbContext();

                var keys = db.Keys;

                Assert.IsInstanceOf<DbSet<Key>>(keys);
            }


            [Test]
            public void KeysDbSet_Always_ReturnsKeyWithAllNotNullProperties()
            {
                var db = GetTestDbContext();

                var key = db.Keys.First(x => x.Id == 1);

                var propList = key.GetType().GetProperties();
                foreach (var prop in propList)
                {
                    var value = prop.GetValue(key);
                    Assert.NotNull(value, "Обнаружено незагруженное поле " + prop.Name + " модели " + key.GetType().ToString() + ". Предварительно проверьте чтобы в тестовой БД в таблице была сущность с id = " + 1 + " и у нее все поля были заполнены (не Null). Если тестовые данные верны, а поле так и не загружено - проверьте Fluent Mapping класса " + key.GetType().ToString() + ".");
                }
            }
        }
    }
}
