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
    public class TestControllerTests_GetAll
    {
        #region Help methods
        private List<TestEntity> GetLongEntityList()
        {
            return new List<TestEntity>()
            {
                new TestEntity() { Id = 1 },
                new TestEntity() { Id = 2 },
                new TestEntity() { Id = 3 },
                new TestEntity() { Id = 4 },
                new TestEntity() { Id = 5 },
            };
        }

        private GenericRestController<TestEntity, int> GetController(IList<TestEntity> list)
        {
            return new GenericRestController<TestEntity, int>(list);
        }
        #endregion

        [Test]
        public void GetAll_EmptyKeyList_ReturnsEmptyList()
        {
            // arrange
            var controller = new TestController(new List<TestEntity>());

            // act
            var list = controller.Get();

            // assert
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void GetAll_Always_ReturnsNotNull()
        {
            // arrange
            var controller = new TestController(new List<TestEntity>());

            // act
            var list = controller.Get();

            // assert
            Assert.NotNull(list);
        }

        [Test]
        public void GetAll_Always_ReturnsIEnumerableKeyCollection()
        {
            var controller = new KeysController(new List<TestEntity>());

            var list = controller.Get();

            Assert.IsInstanceOf<IEnumerable<Key>>(list);
        }

        [Test]
        public void GetAll_Always_ReturnsAllKeys()
        {
            var etalonList = GetLongEntityList();
            var controller = new TestController(etalonList);

            var list = controller.Get();

            Assert.True(list.Count() == etalonList.Count());
            Assert.True(list.All(x => etalonList.Contains(x)));
        }

        // TODO: В будущем этот тест необходимо применить для проверки вызова контроллером generic-контроллера
        [Test]
        [Ignore("Игнорируем проверку использования контроллером фабрики, т.к. фабрика, в результате рефакторинга, более не используется. Контроллер сам хранит свою коллекцию, и тестом ее использования является тест GetAll_Always_ReturnsAllKeys. В будущем этот тест необходимо применить для проверки вызова контроллером generic-контроллера")]
        public void GetAll_Always_CallKeyListFactory()
        {
            var mock = Substitute.For<IList<Key>>();
            var controller = new KeysController();
            //controller.SetEntityCollecton(mock);

            var list = controller.Get();

            mock.Received();
        }
    }
}
