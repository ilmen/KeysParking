using KeysParkingService.BisnessLogic;
using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using System;

namespace KeysParkingService.Controllers
{
    public class KeyGroupsController : AbstractRestController<KeyGroup, Guid>
    {
        private static GenericRestController<KeyGroup, Guid> GetRestController()
        {
            var dbContext = DbContextKeyParking.Instance;
            return new GenericRestController<KeyGroup, Guid>(dbContext, dbContext.KeyGroups);
        }

        public KeyGroupsController()
            : base(KeyGroupsController.GetRestController())
        {

        }
    }
}
