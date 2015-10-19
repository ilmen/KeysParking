using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KeysParkingService.DataAccess
{
    public class DbSetToIListAdaptor<T> : IList<T>
        where T : class
    {
        DbContextKeyParking db;
        DbSet<T> dbCollection;

        public DbSetToIListAdaptor(DbContextKeyParking dbContext, DbSet<T> dbSet)
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