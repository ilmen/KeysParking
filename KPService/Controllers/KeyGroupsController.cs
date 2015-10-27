using KPService.Models;
using KPService.RestLibrary;
using System;

namespace KPService.Controllers
{
    public class KeyGroupsController : UniversalRestController<KeyGroup, Guid>
    {
        private static GenericRestController<KeyGroup, Guid> GetRestController()
        {
            var dbContext = PKDbContext.Instance;
            return new GenericRestController<KeyGroup, Guid>(dbContext, dbContext.KeyGroups);
        }

        public KeyGroupsController()
            : base(KeyGroupsController.GetRestController()) { }
    }
}
