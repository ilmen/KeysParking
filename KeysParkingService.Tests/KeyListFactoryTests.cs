using KeysParkingService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysParkingService.Tests
{
    [TestFixture]
    public class KeyListFactoryTests
    {
        [Test]
        public void SetKeyList_EmptyList_ReturnsEmptyList()
        {
            // arrange
            KeyListFactory.SetKeyList(new List<Key>());
            var factory = new KeyListFactory();

            // act
            var emptyList = factory.Create();

            // assert
            Assert.IsTrue(emptyList.Count == 0);
        }

        [Test]
        public void SetKeyList_List_AlwaysReturnsEqualList()
        {
            var key1 = new Key() { Id = 1 };
            var key2 = new Key() { Id = 2 };
            var key3 = new Key() { Id = 3 };
            KeyListFactory.SetKeyList(new List<Key>() { key1, key2, key3 });
            var factory = new KeyListFactory();

            var list = factory.Create().ToList();

            Assert.Contains(key1, list);
            Assert.Contains(key2, list);
            Assert.Contains(key3, list);
            Assert.True(list.Count == 3);
        }
    }
}
