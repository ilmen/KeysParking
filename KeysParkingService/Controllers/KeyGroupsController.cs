using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using System;

namespace KeysParkingService.Controllers
{
    public class KeyGroupsController : AbstractRestController<KeyGroup, Guid>
    {
        private static GenericRestController<KeyGroup, Guid> GetRestController()
        {
            return new GenericRestController<KeyGroup, Guid>(DbContextKeyParking.Instance, DbContextKeyParking.Instance.KeyGroups);
        }

        public KeyGroupsController()
            : base(KeyGroupsController.GetRestController())
        {

        }
    }

    //public class KeyGroupsController : ApiController
    //{
    //    IList<KeyGroup> KeyGroupStorage { get; set; }

    //    public KeyGroupsController()
    //    {
    //        var dbContext = DbContextKeyParking.Instance;
    //        KeyGroupStorage = new DbSetToIListAdaptor<KeyGroup>(dbContext, dbContext.KeyGroups);
    //    }

    //    internal void SetKeyList(IList<KeyGroup> testList)
    //    {
    //        this.KeyGroupStorage = testList;
    //    }

    //    // GET: api/keys
    //    public IEnumerable<KeyGroup> Get()
    //    {
    //        return KeyGroupStorage;
    //    }

    //    // GET api/keys/5
    //    public KeyGroup Get(Guid uid)
    //    {
    //        return KeyGroupStorage.FirstOrDefault(x => x.GroupId == uid);
    //    }

    //    // POST api/keys
    //    public void Post([FromBody]KeyGroup value)
    //    {
    //        if (value == null) return;
    //        if (KeyGroupStorage.Any(x => x.GroupId == value.GroupId)) throw new InvalidOperationException("WrongId. Элемент с таким Id уже существует");
    //        KeyGroupStorage.Add(value);
    //    }

    //    // PUT api/keys/5
    //    public void Put(Guid uid, [FromBody]KeyGroup value)
    //    {
    //        if (uid != value.GroupId) throw new ArgumentException("WrongId. Id переданный как параметр метода и Id как поле объекта value не совпадают.");

    //        // updating item accross removing
    //        Delete(uid);
    //        Post(value);
    //    }

    //    // DELETE api/keys/5
    //    public void Delete(Guid uid)
    //    {
    //        var toRemove = KeyGroupStorage.FirstOrDefault(x => x.GroupId == uid);
    //        if (toRemove != null) KeyGroupStorage.Remove(toRemove);
    //    }
    //}
}
