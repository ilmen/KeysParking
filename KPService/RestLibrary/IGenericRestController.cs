namespace KPService.RestLibrary
{
    public interface IGenericRestController<T, K>
        where T : class, IGenericEntity<K>
        where K : System.IEquatable<K>
    {
        System.Collections.Generic.IEnumerable<T> Get();

        T Get(K id);

        void Add(T value);

        void Update(K id, T value);

        void Delete(K id);
    }
}
