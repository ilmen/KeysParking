﻿using KPService.RestLibrary;
using System;
using System.Collections.Generic;

namespace KPLibrary.UnitTests
{
    public static class UniversalRestControllerFactory
    {
        public static UniversalRestController<TestEntity, int> GetController(IGenericRestController<TestEntity, int> restController)
        {
            return new UniversalRestController<TestEntity, int>(restController);
        }
    }

    public static class GenericRestControllerFactory
    {
        public static GenericRestController<TestEntity, int> CreateController(IList<TestEntity> list)
        {
            return new GenericRestController<TestEntity, int>(list);
        }
    }

    public class TestEntity : IGenericEntity<int>
    {
        public int Id
        { get; set; }

        public Guid UniqueId
        { get; set; }

        public TestEntity()
        {
            this.UniqueId = Guid.NewGuid();
        }
    }
}
