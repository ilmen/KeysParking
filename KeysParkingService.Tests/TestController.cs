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

        public TestController(IList<TestEntity> list)
            : base(GetController(list))
        {

        }
    }

    public class TestEntity : GenericEntity<int>
    {
        public int Id
        { get; set; }
    }
}
