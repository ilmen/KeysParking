using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace KeysParkingService.Controllers
{
    public abstract class AbstractRestController<T, K> : ApiController
        where T : class, GenericEntity<K>
        where K : IEquatable<K>
    {
        private GenericRestController<T, K> controller;

        public AbstractRestController(GenericRestController<T, K> restController)
        {
            this.controller = restController;
        }

        // TODO: убрать этот public зазор, сделать отдельный класс, наследник от класса GenericRestController, используемый для тестирования. Этом классе протестировать только взаимодействие с GenericRestController
        public void SetEntityCollecton(IList<T> testList)
        {
            controller.SetEntityCollecton(testList);
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
            controller.Post(value);
        }

        public virtual void Put(K id, [FromBody]T value)
        {
            controller.Put(id, value);
        }

        public virtual void Delete(K id)
        {
            controller.Delete(id);
        }
    }
}