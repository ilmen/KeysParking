using KPService.DataAccess;
using KPService.Models;
using KPLibrary;

namespace KPService.Controllers
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
