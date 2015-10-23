using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeysParkingService.BisnessLogic
{
    public interface IGenericEntity<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}