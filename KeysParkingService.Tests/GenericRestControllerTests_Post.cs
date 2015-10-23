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
    public class GenericRestControllerTests_Post
    {
        #region Help methods
        private List<TestEntity> GetLongEntitiesList()
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
        #endregion

        [Test]
        public void Post_NewValue_ValueAddedToEntitiesList()
        {
            // arrange
            var shortList = GetLongEntitiesList();
            var value = new TestEntity() { Id = 6 };
            if (shortList.Any(x => x.Id == value.Id)) throw new Exception("Неверная конфигурация теста. Value не должен содержаться в исходном списке ключей.");

            var controller = new TestController(shortList);

            // act
            controller.Post(value);
            var list = controller.Get();

            // assert
            Assert.NotNull(list.SingleOrDefault(x => x.Id == value.Id));
        }

        [Test]
        public void Post_NullValue_EntitiesListNotChanged()
        {
            var controller = new TestController(new List<TestEntity>());

            controller.Post(null);
            var list = controller.Get();

            Assert.True(list.Count() == 0);
        }

        [Test]
        public void Post_DublicateValueId_ThrowsException()
        {
            var list = GetLongEntitiesList();
            var entity = list.First();
            var controller = new TestController(list);

            Assert.Catch<InvalidOperationException>(new TestDelegate(() => controller.Post(entity)),"WrongId");
        }
    }
}
