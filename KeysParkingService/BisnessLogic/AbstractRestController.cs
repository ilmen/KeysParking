using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KeysParkingService.BisnessLogic
{
    public abstract class AbstractRestController<T, K> : ApiController
        where T : class, IGenericEntity<K>
        where K : IEquatable<K>
    {
        protected IGenericRestController<T, K> controller;

        public AbstractRestController(IGenericRestController<T, K> restController)
        {
            this.controller = restController;
        }

        public virtual IEnumerable<T> Get()
        {
            return controller.Get();
        }

        public virtual T Get(K id)
        {
            return controller.Get(id);
        }

        public virtual void Post([FromBody]T value)
        {
            controller.Add(value);
        }

        public virtual void Put(K id, [FromBody]T value)
        {
            controller.Update(id, value);
        }

        public virtual void Delete(K id)
        {
            controller.Delete(id);
        }
    }
}