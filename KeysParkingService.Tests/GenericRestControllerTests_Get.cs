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
    public class GenericRestControllerTests_Get
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
        public void Get_EmptyEntitiesList_ReturnsNull()
        {
            // arrange
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            // act
            var entity = controller.Get(1);

            // assert
            Assert.Null(entity);
        }

        [Test]
        public void Get_CorrectId_ReturnsCorrectEntities()
        {
            var list = GetLongEntitiesList();
            var controller = GenericRestControllerFactory.CreateController(list);

            // act
            var entity = controller.Get(list.First().Id);

            // assert
            Assert.True(list.First().Id == entity.Id);
        }

        [Test]
        public void Get_Always_ReturnsTestEntityInstance()
        {
            var list = GetLongEntitiesList();
            var controller = GenericRestControllerFactory.CreateController(list);

            var entity = controller.Get(list.First().Id);

            Assert.IsInstanceOf<TestEntity>(entity);
        }
        
        [Test]
        public void Get_WrongId_ReturnsNull()
        {
            var list = GetLongEntitiesList();
            var controller = GenericRestControllerFactory.CreateController(list);

            var entity = controller.Get(-1);

            Assert.Null(entity);
        }
    }
}
