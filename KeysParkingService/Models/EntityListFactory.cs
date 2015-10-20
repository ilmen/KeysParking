using KeysParkingService.DataAccess;
using System.Collections.Generic;
using System.Data.Entity;

namespace KeysParkingService.Models
{
    //public class EntityListFactory<T>
    //    where T: class
    //{
    //    private static EntityListFactory<T> _Instance = new EntityListFactory<T>();
    //    public static EntityListFactory<T> Instance
    //    {
    //        get
    //        {
    //            return _Instance;
    //        }

    //        protected set
    //        {
    //            _Instance = value;
    //        }
    //    }

    //    protected IList<T> EntityStorage { get; set; }

    //    public virtual IList<T> Create()
    //    {
    //        return EntityStorage;
    //    }

    //    protected EntityListFactory(DbContextKeyParking dbContext, DbSet<T> dbSet)
    //    {
    //        EntityStorage = new DbSetToIListAdaptor<T>(dbContext, dbSet);
    //    }
    //}

    //public class MockKeyListFactory : EntityListFactory<Key>
    //{
    //    public static MockKeyListFactory SetNewTestInstance(IList<Key> keys)
    //    {
    //        var fake = new MockKeyListFactory(keys);
    //        Instance = fake;

    //        return fake;
    //    }

    //    public bool CreateMethodWasCalled
    //    { get; private set; }

    //    protected MockKeyListFactory(IList<Key> keys)
    //    {
    //        KeyStorage = keys;
    //    }

    //    public override IList<Key> Create()
    //    {
    //        CreateMethodWasCalled = true;

    //        return base.Create();
    //    }
    //}
}