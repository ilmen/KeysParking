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
    public class KeysControllerTests_Get
    {
        #region Help methods
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
        #endregion

        [Test]
        public void Get_EmptyKeyList_ReturnsNull()
        {
            // arrange
            MockKeyListFactory.SetNewTestInstance(new List<Key>());
            var controller = new KeysController();

            // act
            var key = controller.Get(1);

            // assert
            Assert.Null(key);
        }

        [Test]
        public void Get_CorrectId_ReturnsCorrectKeys()
        {
            var list = GetLongKeyList();
            MockKeyListFactory.SetNewTestInstance(list);
            var controller = new KeysController();

            // act
            var key = controller.Get(list.First().Id);

            // assert
            Assert.True(list.First().Id == key.Id);
        }

        [Test]
        public void Get_Always_ReturnsKeyInstance()
        {
            var list = GetLongKeyList();
            MockKeyListFactory.SetNewTestInstance(list);
            var controller = new KeysController();

            var key = controller.Get(list.First().Id);

            Assert.IsInstanceOf<Key>(key);
        }
        
        [Test]
        public void Get_WrongId_ReturnsNull()
        {
            var list = GetLongKeyList();
            MockKeyListFactory.SetNewTestInstance(list);
            var controller = new KeysController();

            var key = controller.Get(-1);

            Assert.Null(key);
        }
    }
}
