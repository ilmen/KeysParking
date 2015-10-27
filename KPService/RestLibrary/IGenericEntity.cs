namespace KPService.RestLibrary
{
    public interface IGenericEntity<T> where T : System.IEquatable<T>
    {
        T Id { get; set; }
    }
}