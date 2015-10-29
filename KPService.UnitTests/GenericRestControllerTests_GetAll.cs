using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPLibrary.UnitTests
{
    [TestFixture]
    [Category("UnitTests")]
    public class GenericRestControllerTests_GetAll
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
        public void GetAll_EmptyEntitiesList_ReturnsEmptyList()
        {
            // arrange
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            // act
            var list = controller.Get();

            // assert
            Assert.True(list.Count() == 0);
        }

        [Test]
        public void GetAll_Always_ReturnsNotNull()
        {
            // arrange
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            // act
            var list = controller.Get();

            // assert
            Assert.NotNull(list);
        }

        [Test]
        public void GetAll_Always_ReturnsIEnumerableEntitiesCollection()
        {
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            var list = controller.Get();

            Assert.IsInstanceOf<IEnumerable<TestEntity>>(list);
        }

        [Test]
        public void GetAll_Always_ReturnsAllEntities()
        {
            var etalonList = GetLongEntitiesList();
            var controller = GenericRestControllerFactory.CreateController(etalonList);

            var list = controller.Get();

            Assert.True(list.Count() == etalonList.Count());
            Assert.True(list.All(x => etalonList.Contains(x)));
        }
    }
}
