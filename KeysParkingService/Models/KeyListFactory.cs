using System.Collections.Generic;

namespace KeysParkingService.Models
{
    public class KeyListFactory
    {
        private static KeyListFactory _Instance = new KeyListFactory();
        public static KeyListFactory Instance
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

        protected IList<Key> KeyStorage { get; set; }

        public virtual IList<Key> Create()
        {
            return KeyStorage;
        }

        protected KeyListFactory()
        {
            var dbContext = new DB();
            KeyStorage = new DbContextIListAdaptor<Key>(dbContext, dbContext.Keys);
        }
    }

    public class MockKeyListFactory : KeyListFactory
    {
        public static MockKeyListFactory SetNewTestInstance(IList<Key> keys)
        {
            var fake = new MockKeyListFactory(keys);
            Instance = fake;

            return fake;
        }

        public bool CreateMethodWasCalled
        { get; private set; }

        protected MockKeyListFactory(IList<Key> keys)
        {
            KeyStorage = keys;
        }

        public override IList<Key> Create()
        {
            CreateMethodWasCalled = true;

            return base.Create();
        }
    }
}