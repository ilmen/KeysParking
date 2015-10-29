﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KPLibrary.UnitTests
{
    [TestFixture]
    [Category("UnitTests")]
    public class GenericRestControllerTests_Delete
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
        public void Delete_LongEntitiesList_EntityBeDeleted()
        {
            // arrange
            var list = GetLongEntitiesList();
            var elementToRemove = list.First();
            var controller = GenericRestControllerFactory.CreateController(list);

            // act
            controller.Delete(elementToRemove.Id);

            // assert
            Assert.False(list.Contains(elementToRemove));
        }

        [Test]
        public void Delete_ListWithOneEntity_AfterDeleteListBeEmpty()
        {
            // arrange
            var entity = new TestEntity() { Id = 1 };
            var list = new List<TestEntity>() { entity };
            var controller = GenericRestControllerFactory.CreateController(list);

            // act
            controller.Delete(entity.Id);

            // assert
            Assert.True(list.Count == 0);
        }

        [Test]
        public void Delete_EmptyEntitiesList_CallDeleteWithoutException()
        {
            // arrange
            var controller = GenericRestControllerFactory.CreateController(new List<TestEntity>());

            // act
            // assert
            controller.Delete(0);
        }

        [Test]
        public void Delete_WrongId_ListNotChanged()
        {
            // arrange
            var list = GetLongEntitiesList();
            var controller = GenericRestControllerFactory.CreateController(list);

            // act
            controller.Delete(-1);

            // assert
            Assert.True(list.Count == GetLongEntitiesList().Count);
        }
    }
}