using KPLibrary;
using KPService.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPService.Tests.IntegrationTests
{
    public partial class IntegrationTests
    {
        [TestFixture]
        public class KeysControllerTests
        {
            [Test]
            public void GetKeys_Always_ReturnsIQueryableOfKey()
            {
                var controller = new KeysController();

                var keys = controller.GetKeys();

                Assert.IsInstanceOf<IQueryable<Key>>(keys);
            }

            [Test]
            public void GetKeys_Always_ReturnsCollectionOfThreeKeys()
            {
                var controller = new KeysController();

                var keys = controller.GetKeys();

                Assert.AreEqual(3, keys.Count());
            }


        }
    }
}
