﻿using System;
using System.Collections.Generic;

namespace KeysParkingService.Models
{
    public interface IGenericRestController<T, K>
        where T : class, GenericEntity<K>
        where K : IEquatable<K>
    {
        IEnumerable<T> Get();

        T Get(K id);

        void Add(T value);

        void Update(K id, T value);

        void Delete(K id);
    }
}