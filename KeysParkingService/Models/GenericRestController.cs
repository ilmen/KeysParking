using KeysParkingService.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.Http;
[assembly: InternalsVisibleTo("KeysParkingService.Tests")]

namespace KeysParkingService.Models
{
    public class GenericRestController<T, K> : ApiController
        where T : class, GenericEntity<K>
        where K : IEquatable<K>
    {
        IList<T> EntityStorage { get; set; }

        public GenericRestController(DbContextKeyParking dbContext, DbSet<T> dbCollection)
        {
            EntityStorage = new DbSetToIListAdaptor2<T, K>(dbContext, dbCollection);
        }

        internal void SetEntityCollecton(IList<T> testList)
        {
            this.EntityStorage = testList;
        }

        public IEnumerable<T> Get()
        {
            return EntityStorage;
        }

        public T Get(K id)
        {
            return EntityStorage.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Post([FromBody]T value)
        {
            if (value == null) return;
            if (EntityStorage.Any(x => x.Id.Equals(value.Id))) throw new InvalidOperationException("WrongId. Элемент с таким Id уже существует");
            EntityStorage.Add(value);
        }

        public void Put(K id, [FromBody]T value)
        {
            if (!id.Equals(value.Id)) throw new ArgumentException("WrongId. Id переданный как параметр метода и Id как поле объекта value не совпадают.");

            // updating item accross removing
            Delete(id);
            Post(value);
        }

        public void Delete(K id)
        {
            var toRemove = EntityStorage.FirstOrDefault(x => x.Id.Equals(id));
            if (toRemove != null) EntityStorage.Remove(toRemove);
        }
    }
}