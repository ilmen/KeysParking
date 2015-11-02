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

            private void RemoveAllKeys()
            {
                var db = GetTestDbContext();
                var keys = db.Keys.ToList();
                db.Keys.RemoveRange(keys);
                db.SaveChanges();
            }

            private IEnumerable<Key> GetDefaultKeyCollection()
            {
                return new List<Key>()
                {
                    new Key()
                    {
                        Id = 1,
                        GroupId = new Guid("009159ce-af3f-4c8d-9eae-a9244eea2067"),
                        Login = "qwerty",
                        Password = "qwerty",
                        SiteLink = "www.qwerty.com",
                        CreateTime = new DateTime(2013, 1, 1, 8, 0, 0),
                    },
                    new Key()
                    {
                        Id = 2,
                        GroupId = new Guid("009159ce-af3f-4c8d-9eae-a9244eea2067"),
                        Login = "mylogin",
                        Password = "mypassword",
                        SiteLink = "www.mail.ru",
                        CreateTime = new DateTime(2014, 2, 2, 12, 50, 2),
                    },
                    new Key()
                    {
                        Id = 3,
                        GroupId = new Guid("750520aa-1e27-457c-9e6d-2144d3c897ee"),
                        Login = "adm",
                        Password = "adm",
                        SiteLink = "www.ya.ru",
                        CreateTime = new DateTime(2015, 3, 3, 6, 10, 10),
                    }
                };
            }
            #endregion

            [SetUp]
            [TearDown]
            public void RestoreKeysInDb()
            {
                RemoveAllKeys();

                var keys = GetDefaultKeyCollection();

                var db = GetTestDbContext();
                db.Keys.AddRange(keys);
                db.SaveChanges();
            }

            [Test]
            public void KeysDbSet_AfterCallRemove_ReturnsEmptyCollection()
            {
                RemoveAllKeys();
                var db = GetTestDbContext();
                var keysCount = db.Keys.Count<Key>();

                Assert.AreEqual(0, keysCount);
            }

            [Test]
            public void KeyDbSet_Always_ReturnsNotEmptyCollection()
            {
                var db = GetTestDbContext();

                var keysCount = db.Keys.Count<Key>();

                Assert.Greater(keysCount, 0);
            }

            [Test]
            public void KeysDbSet_Always_ReturnsDbSetOfKeyInstance()
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
