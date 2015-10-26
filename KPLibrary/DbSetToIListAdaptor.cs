using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace KPLibrary
{
    public class DbSetToIListAdaptor<T, K> : IList<T>
        where T : class, IGenericEntity<K>
        where K : IEquatable<K>
    {
        DbContext db;
        DbSet<T> dbCollection;

        public DbSetToIListAdaptor(DbContext dbContext, DbSet<T> dbSet)
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

        public int Count
        {
            // TODO: исправить, не использовать Local
            get { return dbCollection.Local.Count; }
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

        public bool IsReadOnly
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}