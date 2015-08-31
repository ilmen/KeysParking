using KeysParkingService.Controllers;
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
    public class KeysControllerTests
    {
        [Test]
        public void Delete_LongKeyList_KeyBeDeleted()
        {
            // arrange
            var list = GetLongKeyList();
            KeyListFactory.SetKeyList(list);
            var elementToRemove = list.First();
            var controller = new KeysController();

            // act
            controller.Delete(elementToRemove.Id);

            // assert
            Assert.False(list.Contains(elementToRemove));
        }

        [Test]
        public void Delete_ListWithOneKey_AfterDeleteListBeEmpty()
        {
            // arrange
            var key = new Key() { Id = 1, Login = "l", Password = "p" };
            var list = new List<Key>() { key };
            KeyListFactory.SetKeyList(list);
            var controller = new KeysController();

            // act
            controller.Delete(key.Id);

            // assert
            Assert.True(list.Count == 0);
        }

        [Test]
        public void Delete_EmptyList_CallDeleteWithoutException()
        {
            // arrange
            KeyListFactory.SetKeyList(new List<Key>());
            var controller = new KeysController();

            // act
            // assert
            controller.Delete(0);
        }

        [Test]
        public void Delete_WrongId_ListNotChanged()
        {
            // arrange
            var list = GetLongKeyList();
            KeyListFactory.SetKeyList(list);
            var controller = new KeysController();

            // act
            controller.Delete(-1);

            // assert
            Assert.True(list.Count == GetLongKeyList().Count);
        }

        private List<Key> GetLongKeyList()
        {
            return new List<Key>()
            {
                new Key() { Id = 1, Login = "login1", Password = "password1" },
                new Key() { Id = 2, Login = "login2", Password = "password2" },
                new Key() { Id = 3, Login = "login3", Password = "password3" },
                new Key() { Id = 4, Login = "login4", Password = "password4" },
                new Key() { Id = 5, Login = "login5", Password = "password5" },
            };
        }
    }
}
