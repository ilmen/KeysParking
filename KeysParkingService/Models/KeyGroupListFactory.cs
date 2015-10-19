using KeysParkingService.DataAccess;
using System.Collections.Generic;

namespace KeysParkingService.Models
{
    public class KeyGroupListFactory
    {
        private static KeyGroupListFactory _Instance = new KeyGroupListFactory();
        public static KeyGroupListFactory Instance
        {
            get
            {
                return _Instance;
            }

            protected set
            {
                _Instance = value;
            }
        }

        protected IList<KeyGroup> KeyGroupStorage { get; set; }

        public virtual IList<KeyGroup> Create()
        {
            return KeyGroupStorage;
        }

        protected KeyGroupListFactory()
        {
            var dbContext = new DbContextKeyParking();
            KeyGroupStorage = new DbSetToIListAdaptor<KeyGroup>(dbContext, dbContext.Groups);
        }
    }

    //public class MockKeyListFactory : KeyListFactory
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