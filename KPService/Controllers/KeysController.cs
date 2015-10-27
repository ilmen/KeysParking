using KPService.Models;
using KPService.RestLibrary;
using System.Web.Http;

namespace KPService.Controllers
{
    public class KeysController : UniversalRestController<Key, int>
    {
        private static GenericRestController<Key, int> GetRestController()
        {
            var dbContext = PKDbContext.Instance;
            return new GenericRestController<Key, int>(dbContext, dbContext.Keys);
        }

        public KeysController()
            : base(KeysController.GetRestController())
        {

        }
    }
}
