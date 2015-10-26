using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using KPLibrary;

namespace KeysParkingService.Controllers
{
    public class KeysController : UniversalRestController<Key, int>
    {
        private static GenericRestController<Key, int> GetRestController()
        {
            var dbContext = DbContextKeyParking.Instance;
            return new GenericRestController<Key, int>(dbContext, dbContext.Keys);
        }

        public KeysController()
            : base(KeysController.GetRestController())
        {

        }
    }
}
