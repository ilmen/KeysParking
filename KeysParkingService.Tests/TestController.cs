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
            return new GenericRestController<TestEntity, int>(list);
        }

        public TestController(IList<TestEntity> list) : base(GetController(list)) { }

        public TestController(IGenericRestController<TestEntity, int> restController) : base(restController) { }
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
}
