using KPService.Controllers;
using KPService.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.IntegrityTests
{
    [TestFixture]
    [Category("IntegrityTests")]
    public class KeyGroupsControllerTests
    {
        [Test]
        public void GetOne_Always_ReturnsNotNull()
        {
            var controller = new KeyGroupsController();

            var group = controller.Get(new Guid("750520aa-1e27-457c-9e6d-2144d3c897ee"));

            Assert.NotNull(group);
        }

        [Test]
        public void GetAll_Always_ReturnsInstanceOfIListKeyGroupCollection()
        {
            var controller = new KeyGroupsController();

            var keyGroups = controller.Get();

            // TODO: исправить, использовать в контроллерах IQueryable<KeyGroup>, поправить и название теста
            Assert.IsInstanceOf<IList<KeyGroup>>(keyGroups);
        }
    }
}
