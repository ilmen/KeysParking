using System.Collections.Generic;

namespace KeysParkingService.Models
{
    public class KeyListFactory
    {
        static IList<Key> keyStorage;

        public KeyListFactory()
        {
            // todo: добавить работу с БД
            if (keyStorage == null)
            {
                keyStorage = new List<Key>()
                {
                    new Key() { Id = 1, Login = "qwerty", Password = "qwerty" },
                    new Key() { Id = 2, Login = "adm", Password = "adm" },
                };
            }
        }

        public IList<Key> Create()
        {
            return keyStorage;
        }

        public void SetKeyList(IList<Key> keys)
        {
            keyStorage = keys;
        }
    }

    //[TestFixture]
    //public class KeyListFactoryTest
    //{
    //    [Test]
    //    public void SetKeyList_Empty_RerurnsEmpty()
    //    {
    //        var emptyKeyStorage = new List<Key>();

    //        var keyStorageFactory = new KeyStorageFactory();
    //        keyStorageFactory
    //    }
    //}
}