using KeysParkingService.Controllers;
using KeysParkingService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysParkingService.Tests
{
    public class TestController : AbstractRestController<TestEntity, int>
    {
        private static GenericRestController<TestEntity, int> GetController(IList<TestEntity> list)
        {
            return new FakeGenericRestController(list);
        }

        public TestController(IList<TestEntity> list) : base(GetController(list)) { }

        public FakeGenericRestController GetController()
        {
            return (FakeGenericRestController)this.controller;
        }
    }

    public class TestEntity : GenericEntity<int>
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

    public class FakeGenericRestController : GenericRestController<TestEntity, int>
    {
        public bool GetAllCalled
        { get; set; }
        public bool GetOneCalled
        { get; set; }
        public bool AddCalled
        { get; set; }
        public bool UpdateCalled
        { get; set; }
        public bool DeleteCalled
        { get; set; }

        public FakeGenericRestController(IList<TestEntity> list) : base(list) { }

        public override IEnumerable<TestEntity> Get()
        {
            GetAllCalled = true;
            return base.Get();
        }

        public override TestEntity Get(int id)
        {
            GetOneCalled = true;
            return base.Get(id);
        }

        public override void Add(TestEntity value)
        {
            AddCalled = true;
            base.Add(value);
        }

        public override void Update(int id, TestEntity value)
        {
            UpdateCalled = true;
            base.Update(id, value);
        }

        public override void Delete(int id)
        {
            DeleteCalled = true;
            base.Delete(id);
        }
    }
}
