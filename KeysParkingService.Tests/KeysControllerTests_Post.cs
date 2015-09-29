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
    public class KeysControllerTests_Post
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
        public void Post_NewValue_ValueAddedToKeyList()
        {
            // arrange
            var shortList = GetLongKeyList();
            var value = new Key() {
                Id = 6,
                Login = "OtherLogin",
                Password = "OtherPassword"
            };
            if (shortList.Any(x => x.Id == value.Id)) throw new Exception("Неверная конфигурация теста. Value не должен содержаться в исходном списке ключей.");

            MockKeyListFactory.SetNewTestInstance(shortList);
            var controller = new KeysController();

            // act
            controller.Post(value);
            var list = controller.Get();

            // assert
            Assert.NotNull(list.SingleOrDefault(x => x.Id == value.Id));
        }

        [Test]
        public void Post_NullValue_KeyListNotChanged()
        {
            MockKeyListFactory.SetNewTestInstance(new List<Key>());
            var controller = new KeysController();

            controller.Post(null);
            var list = controller.Get();

            Assert.True(list.Count() == 0);
        }

        [Test]
        public void Post_DublicateValueId_ThrowsException()
        {
            var list = GetLongKeyList();
            var key = list.First();
            MockKeyListFactory.SetNewTestInstance(list);
            var controller = new KeysController();

            Assert.Catch<InvalidOperationException>(new TestDelegate(() => controller.Post(key)),"WrongId");
        }
    }
}
