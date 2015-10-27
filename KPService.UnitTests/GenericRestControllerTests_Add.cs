using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPLibrary.UnitTests
{
    [TestFixture]
    public class GenericRestControllerTests_Add
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
        public void Add_NewValue_ValueAddedToEntitiesList()
        {
            // arrange
            var shortList = GetLongEntitiesList();
            var value = new TestEntity() { Id = 6 };
            if (shortList.Any(x => x.Id == value.Id)) throw new Exception("Неверная конфигурация теста. Value не должен содержаться в исходном списке ключей.");

            var controller = GenericRestControllerFactory.CreateController(shortList);

            // act
            controller.Add(value);
            var list = controller.Get();

            // assert
            Assert.NotNull(list.SingleOrDefault(x => x.Id == value.Id));
        }

        [Test]
        public void Add_NullValue_EntitiesListNotChanged()
        {
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            controller.Add(null);
            var list = controller.Get();

            Assert.True(list.Count() == 0);
        }

        [Test]
        public void Add_DublicateValueId_ThrowsException()
        {
            var list = GetLongEntitiesList();
            var entity = list.First();
            var controller = GenericRestControllerFactory.CreateController(list);

            Assert.Catch<InvalidOperationException>(new TestDelegate(() => controller.Add(entity)),"WrongId");
        }
    }
}
