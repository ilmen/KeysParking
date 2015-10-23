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
    public class GenericRestControllerTests_Update
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
        public void Update_WrongId_AddedToEntitiesList()
        {
            // arrange
            var shortList = GetLongEntitiesList();
            var value = new TestEntity() { Id = 6 };
            if (shortList.Any( x=> x.Id == value.Id)) throw new Exception("Неверная конфигурация теста. Value не должен содержаться в исходном списке ключей.");
            var controller = new TestableGenericRestController(shortList);

            // act
            controller.Update(value.Id, value);
            var list = controller.Get();

            // assert
            Assert.NotNull(list.SingleOrDefault(x => x.Id == value.Id));
        }

        [Test]
        public void Update_CorrectId_ElementOfEntitiesListUpdated()
        {
            var etalonList = GetLongEntitiesList();
            var valueId = etalonList.First().Id;
            var value = new TestEntity() { Id = valueId, UniqueId = Guid.NewGuid() };
            var controller = new TestableGenericRestController(etalonList);

            controller.Update(valueId, value); 
            var list = controller.Get();

            var updatedValue = list.Single(x => x.Id == valueId);
            Assert.True(updatedValue.UniqueId == value.UniqueId);
        }

        [Test]
        public void Update_CorrectId_OtherElementsOfEntitiesListNotUpdated()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();

            var etalonList = new List<TestEntity>()
            {
                new TestEntity() { Id = 1, UniqueId = guid1 },
                new TestEntity() { Id = 2, UniqueId = guid2 },
            };
            var value = new TestEntity() { Id = 3 };
            var controller = new TestableGenericRestController(etalonList);

            controller.Update(value.Id, value);
            var list = controller.Get();

            var notUpdatedElements = list.Where(x => x.Id != value.Id).ToArray();
            Assert.AreEqual(notUpdatedElements[0].Id, 1);
            Assert.AreEqual(notUpdatedElements[0].UniqueId, guid1);

            Assert.AreEqual(notUpdatedElements[1].Id, 2);
            Assert.AreEqual(notUpdatedElements[1].UniqueId, guid2);
        }

        [Test]
        public void Update_IdAsMethodArgumentAndIdAsValueFieldNotEquals_ThrowArgumentException()
        {
            var list = GetLongEntitiesList();
            var value = list.First();
            var controller = new TestableGenericRestController(list);

            Assert.Catch<ArgumentException>(new TestDelegate(() => controller.Update(-1, value)), "WrongId");
        }
    }
}
