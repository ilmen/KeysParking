using KeysParkingService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace KeysParkingService.Controllers
{
    public class KeysController : ApiController
    {
        IList<Key> KeyStorage { get; set; }

        public KeysController()
        {
            KeyStorage = GetKeyListFactory().Create();
        }

        /// <summary>
        /// Seam for testing KeysController and KeyListFactory interaction
        /// </summary>
        protected virtual KeyListFactory GetKeyListFactory()
        {
            return new KeyListFactory();
        }

        // GET: api/keys
        public IEnumerable<Key> Get()
        {
            return KeyStorage;
        }

        // GET api/keys/5
        public Key Get(int id)
        {
            return KeyStorage.FirstOrDefault(x => x.Id == id);
        }

        // POST api/keys
        public void Post([FromBody]Key value)
        {
            KeyStorage.Add(value);
        }

        // PUT api/keys/5
        public void Put(int id, [FromBody]Key value)
        {
            // updating item accross removing
            Delete(id);
            Post(value);
        }

        // DELETE api/keys/5
        public void Delete(int id)
        {
            var toRemove = KeyStorage.FirstOrDefault(x => x.Id == id);
            if (toRemove != null) KeyStorage.Remove(toRemove);
        }
    }
}
