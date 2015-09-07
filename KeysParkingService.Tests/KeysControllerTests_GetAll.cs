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
            KeyListFactory.SetKeyList(new List<Key>());
            var controller = new KeysController();

            // act
            var list = controller.Get();

            // assert
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void GetAll_Always_ReturnsNotNull()
        {
            // arrange
            KeyListFactory.SetKeyList(new List<Key>());
            var controller = new KeysController();

            // act
            var list = controller.Get();

            // assert
            Assert.NotNull(list);
        }

        [Test]
        public void GetAll_Always_ReturnsIEnumerableKeyCollection()
        {
            KeyListFactory.SetKeyList(new List<Key>());
            var controller = new KeysController();

            var list = controller.Get();

            Assert.IsInstanceOf<IEnumerable<Key>>(list);
        }

        [Test]
        public void GetAll_Always_ReturnsAllKeys()
        {
            var etalonList = GetLongKeyList();
            KeyListFactory.SetKeyList(etalonList);
            var controller = new KeysController();

            var list = controller.Get();

            Assert.True(list.Count() == etalonList.Count());
            Assert.True(list.All(x => etalonList.Contains(x)));
        }

        [Test]
        public void GetAll_Always_CallKeyListFactory()
        {
            var factoryMock = new KeyListFactoryFake(GetLongKeyList());
            KeysControllerWithKeyListFactoryInteractionTest.KeyListFactoryMock = factoryMock;
            var controller = new KeysControllerWithKeyListFactoryInteractionTest();

            var list = controller.Get();

            Assert.True(factoryMock.WasCalled);
        }
    }

    public class KeysControllerWithKeyListFactoryInteractionTest : KeysController
    {
        public static KeyListFactory KeyListFactoryMock
        { get; set; }

        protected override KeyListFactory GetKeyListFactory()
        {
            return KeyListFactoryMock;
        }
    }

    /// <summary>
    /// Фабрика ключей для тестирования взаимодействия с классом KeysController
    /// </summary>
    public class KeyListFactoryFake : KeyListFactory
    {
        public bool WasCalled
        { get; set; }

        public IList<Key> KeyList
        { get; set; }

        public KeyListFactoryFake(IList<Key> keyList)
        {
            this.KeyList = keyList;
        }

        public override IList<Key> Create()
        {
            WasCalled = true;

            return KeyList;
        }
    }
}
