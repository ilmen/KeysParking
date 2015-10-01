using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KeysParkingService.Models
{
    public class DB : DbContext
    {
        public DB() : base(nameOrConnectionString: "MonkeyFist") { }
        public DbSet<Key> Keys { get; set; }
    }

    public class KeysDbContextIListAdaptor : IList<Key>
    {
        DB db;

        public KeysDbContextIListAdaptor(DB dbContext)
        {
            db = dbContext;
        }

        public void Add(Key item)
        {
            db.Keys.Add(item);
            db.SaveChanges();
        }

        public bool Remove(Key item)
        {
            db.Keys.Remove(item);
            db.SaveChanges();
            return true;
        }

        public IEnumerator<Key> GetEnumerator()
        {
            var enumerable = db.Keys as IEnumerable<Key>;
            return enumerable.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)GetEnumerator();
        }

        #region Not implemented methods
        public int IndexOf(Key item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Key item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public Key this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Key item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Key[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return  db.Keys..CountAsync(); }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        } 
        #endregion
    }

}