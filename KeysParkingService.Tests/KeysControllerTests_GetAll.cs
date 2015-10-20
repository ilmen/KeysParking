using KeysParkingService.Controllers;
using KeysParkingService.Models;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysParkingService.Tests
{
    [TestFixture]
    public class KeysControllerTests_GetAll
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
        public void GetAll_EmptyKeyList_ReturnsEmptyList()
        {
            // arrange
            var controller = new KeysController();
            controller.SetKeyList(new List<Key>());

            // act
            var list = controller.Get();

            // assert
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void GetAll_Always_ReturnsNotNull()
        {
            // arrange
            var controller = new KeysController();
            controller.SetKeyList(new List<Key>());

            // act
            var list = controller.Get();

            // assert
            Assert.NotNull(list);
        }

        [Test]
        public void GetAll_Always_ReturnsIEnumerableKeyCollection()
        {
            var controller = new KeysController();
            controller.SetKeyList(new List<Key>());

            var list = controller.Get();

            Assert.IsInstanceOf<IEnumerable<Key>>(list);
        }

        [Test]
        public void GetAll_Always_ReturnsAllKeys()
        {
            var etalonList = GetLongKeyList();
            var controller = new KeysController();
            controller.SetKeyList(etalonList);

            var list = controller.Get();

            Assert.True(list.Count() == etalonList.Count());
            Assert.True(list.All(x => etalonList.Contains(x)));
        }

        [Test]
        public void GetAll_Always_CallKeyListFactory()
        {
            var mock = Substitute.For<IList<Key>>();
            var controller = new KeysController();
            controller.SetKeyList(mock);

            var list = controller.Get();

            mock.Received();
        }
    }
}
