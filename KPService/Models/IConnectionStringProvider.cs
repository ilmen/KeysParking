using System;

namespace KPService.Models
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}
