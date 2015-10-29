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
    public class KeysControllerTests
    {
        [Test]
        public void GetAll_Always_ReturnsThreeKeys()
        {
            var controller = new KeysController();

            var keys = controller.Get();

            throw new Exception(keys.Count().ToString());
            Assert.True(keys.Count() == 3);
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
