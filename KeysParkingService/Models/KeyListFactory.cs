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

        public IList<Key> Create()
        {
            return KeyStorage;
        }

        protected KeyListFactory()
        {
            var dbContext = new DB();
            KeyStorage = new KeysDbContextIListAdaptor(dbContext);
        }
    }

    public class TestKeyListFactory : KeyListFactory
    {
        public static void SetNewTestInstance(IList<Key> keys)
        {
            Instance = new TestKeyListFactory(keys);
        }

        protected TestKeyListFactory(IList<Key> keys)
        {
            KeyStorage = keys;
        }
    }
}