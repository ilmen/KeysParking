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

        public virtual IList<Key> Create()
        {
            return keyStorage;
        }

        public static void SetKeyList(IList<Key> keys)
        {
            keyStorage = keys;
        }
    }
}