using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KeysParkingService.Models
{
    public class DB : DbContext
    {
        public DB() : base(nameOrConnectionString: "MonkeyFist") { }
        
        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyGroup> Groups { get; set; }
    }

    public class DbContextIListAdaptor<T> : IList<T>
        where T : class
    {
        DB db;
        DbSet<T> dbCollection;

        public DbContextIListAdaptor(DB dbContext, DbSet<T> dbSet)
        {
            db = dbContext;
            dbCollection = dbSet;
        }

        public void Add(T item)
        {
            dbCollection.Add(item);
            db.SaveChanges();
        }

        public bool Remove(T item)
        {
            dbCollection.Remove(item);
            db.SaveChanges();
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var enumerable = dbCollection as IEnumerable<T>;
            return enumerable.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (System.Collections.IEnumerator)GetEnumerator();
        }

        #region Not implemented methods
        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public T this[int index]
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

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return db.Keys.Local.Count; }
        }

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        } 
        #endregion
    }
}