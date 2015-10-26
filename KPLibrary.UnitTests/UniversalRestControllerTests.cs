using KPLibrary;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KPLibrary.UnitTests
{
    [TestFixture]
    public class UniversalRestControllerTests
    {
        #region Help MethodGenericRestControllers
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
        public void GetAll_Always_CallGetAllMethodGenericRestController()
        {
            var mock = Substitute.For<IGenericRestController<TestEntity, int>>();
            var controller = UniversalRestControllerFactory.GetController(mock);

            var list = controller.Get();

            mock.Received().Get();
        }

        [Test]
        public void Get_Always_CallGetOneMethodGenericRestController()
        {
            var mock = Substitute.For<IGenericRestController<TestEntity, int>>();
            mock.Get(1).Returns(new TestEntity() { Id = 1 });
            var controller = UniversalRestControllerFactory.GetController(mock);

            var value = controller.Get(1);

            mock.Received().Get(Arg.Any<int>());
        }

        [Test]
        public void Post_Always_CallAddMethodGenericRestController()
        {
            var value = new TestEntity() { Id = 10 };
            var mock = Substitute.For<IGenericRestController<TestEntity, int>>();
            var controller = UniversalRestControllerFactory.GetController(mock);

            controller.Post(value);

            mock.Received().Add(value);
        }

        [Test]
        public void Put_Always_CallUpdateMethodGenericRestController()
        {
            var list = GetLongEntitiesList();
            var value = new TestEntity() { Id = list.First().Id, UniqueId = Guid.NewGuid() };
            var mock = Substitute.For<IGenericRestController<TestEntity, int>>();
            mock.Get().Returns(list);
            var controller = UniversalRestControllerFactory.GetController(mock);

            controller.Put(value.Id, value);

            mock.Received().Update(value.Id, value);
        }

        [Test]
        public void Delete_Always_CallDeleteMethodGenericRestController()
        {
            var mock = Substitute.For<IGenericRestController<TestEntity, int>>();
            mock.Get(1).Returns(new TestEntity() { Id = 1 });
            var controller = UniversalRestControllerFactory.GetController(mock);

            controller.Delete(1);

            mock.Received().Delete(Arg.Any<int>());
        }
    }
}
