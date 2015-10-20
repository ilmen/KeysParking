using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace KeysParkingService.Models
{
    //// TODO: сделать общий, протестированный, контроллер для любой коллекции объектов EF

    //public interface IEntityWithPrimaryKey
    //{
    //    int PrimaryId { get; set; }
    //}

    //public interface IRestController
    //{
    //    IEnumerable<IEntityWithPrimaryKey> GetAll();

    //    IEntityWithPrimaryKey GetOne(int key);

    //    void Remove(int key);

    //    void Add(IEntityWithPrimaryKey entity);

    //    void Update(IEntityWithPrimaryKey entity);
    //}

    //public class RestController : IRestController
    //{
    //    ObservableCollection<IEntityWithPrimaryKey> collection;

    //    public RestController(IEnumerable<IEntityWithPrimaryKey> collection)
    //    {
    //        this.collection = new ObservableCollection<IEntityWithPrimaryKey>(collection);
    //    }

    //    public IEnumerable<IEntityWithPrimaryKey> GetAll()
    //    {
    //        return collection;
    //    }

    //    public IEntityWithPrimaryKey GetOne(int key)
    //    {
    //        return collection.FirstOrDefault(x => x.PrimaryId == key);
    //    }

    //    public void Remove(int key)
    //    {
    //        var item = this.GetOne(key);
    //        if (item == null) return;

    //        collection.Remove(item);
    //    }

    //    public void Add(IEntityWithPrimaryKey entity)
    //    {
    //        collection.Add(entity);
    //    }

    //    public void Update(IEntityWithPrimaryKey entity)
    //    {
    //        Remove(entity.PrimaryId);
    //        Add(entity);
    //    }
    //}
}