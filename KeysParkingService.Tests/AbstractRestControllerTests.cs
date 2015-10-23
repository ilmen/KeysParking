using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysParkingService.Tests
{
    [TestFixture]
    public class AbstractRestControllerTests
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
        public void GetAll_Always_CallGenericRestController()
        {
            var controller = new TestController(GetLongEntitiesList());
            var mock = controller.GetController();

            var list = controller.Get();

            Assert.True(mock.GetAllCalled);
        }

        [Test]
        public void Get_Always_CallGenericRestController()
        {
            var controllerList = GetLongEntitiesList();
            var value = controllerList.First();
            var controller = new TestController(controllerList);
            var mock = controller.GetController();

            var list = controller.Get(value.Id);

            Assert.True(mock.GetOneCalled);
        }

        [Test]
        public void Post_Always_CallGenericRestController()
        {
            var value = new TestEntity() { Id = 10 };
            var controller = new TestController(GetLongEntitiesList());
            var mock = controller.GetController();

            controller.Post(value);

            Assert.True(mock.AddCalled);
        }

        [Test]
        public void Put_Always_CallGenericRestController()
        {
            var controllerList = GetLongEntitiesList();
            var value = new TestEntity() { Id = controllerList.First().Id, UniqueId = Guid.NewGuid() };
            var controller = new TestController(controllerList);
            var mock = controller.GetController();

            controller.Put(value.Id, value);

            Assert.True(mock.UpdateCalled);
        }

        [Test]
        public void Delete_Always_CallGenericRestController()
        {
            var controllerList = GetLongEntitiesList();
            var value = controllerList.First();
            var controller = new TestController(controllerList);
            var mock = controller.GetController();

            controller.Delete(value.Id);

            Assert.True(mock.DeleteCalled);
        }
    }
}
