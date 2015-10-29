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
    public class KeysControllerTests
    {
        [Test]
        public void GetOne_Always_ReturnsNotNull()
        {
            var controller = new KeysController();

            var key = controller.Get(1);

            Assert.NotNull(key);
        }

        [Test]
        public void GetAll_Always_ReturnsInstanceOfIListKeyCollection()
        {
            var controller = new KeysController();

            var keys = controller.Get();

            // TODO: исправить, использовать в контроллерах IQueryable<Key>, поправить и название теста
            Assert.IsInstanceOf<IList<Key>>(keys);
        }
    }
}
