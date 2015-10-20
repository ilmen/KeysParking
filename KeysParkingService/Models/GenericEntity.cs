using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeysParkingService.Models
{
    public interface GenericEntity<T> where T : IEquatable<T>
    {
        T Id { get; set; }
    }
}