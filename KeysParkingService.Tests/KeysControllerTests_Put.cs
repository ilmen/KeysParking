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
    public class KeysControllerTests_Put
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
        public void Put_WrongId_AddedToKeyList()
        {
            // arrange
            var shortList = GetLongKeyList();
            var value = new Key() {
                Id = 6,
                Login = "OtherLogin",
                Password = "OtherPassword"
            };
            if (shortList.Any( x=> x.Id == value.Id)) throw new Exception("Неверная конфигурация теста. Value не должен содержаться в исходном списке ключей.");
            KeyListFactory.SetKeyList(shortList);
            var controller = new KeysController();

            // act
            controller.Put(value.Id, value);
            var list = controller.Get();

            // assert
            Assert.NotNull(list.SingleOrDefault(x => x.Id == value.Id));
        }

        [Test]
        public void Put_CorrectId_ElementOfKeyListUpdated()
        {
            var etalonList = GetLongKeyList();
            var valueId = etalonList.First().Id;
            var value = new Key() {
                Id = valueId,
                Login = "testUpdate",
                Password = "testUpdate"
            };
            KeyListFactory.SetKeyList(etalonList);
            var controller = new KeysController();

            controller.Put(valueId, value); 
            var list = controller.Get();

            var updatedValue = list.Single(x => x.Id == valueId);
            Assert.True(updatedValue.Login == value.Login);
            Assert.True(updatedValue.Password == value.Password);
        }

        [Test]
        public void Put_CorrectId_OtherElementsOfKeyListNotUpdated()
        {
            var etalonList = GetLongKeyList();
            var value = new Key()
            {
                Id = 3,
                Login = "testUpdate",
                Password = "testUpdate"
            };
            KeyListFactory.SetKeyList(etalonList);
            var controller = new KeysController();

            controller.Put(value.Id, value);
            var list = controller.Get();

            var notUpdatedElements = list.Where(x => x.Id != value.Id);
            Assert.True(notUpdatedElements.All(x => x.Login == ("login" + x.Id) && x.Password == ("password" + x.Id)));
        }

        [Test]
        public void Put_IdAsMethodArgumentAndIdAsValueFieldNotEquals_ThrowArgumentException()
        {
            var list = GetLongKeyList();
            var value = list.First();
            KeyListFactory.SetKeyList(list);
            var controller = new KeysController();

            Assert.Catch<ArgumentException>(new TestDelegate(() => controller.Put(-1, value)), "WrongId");
        }
    }
}
