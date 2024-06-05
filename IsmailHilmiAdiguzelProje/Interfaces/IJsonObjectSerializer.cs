using System.Diagnostics.Metrics;

namespace IsmailHilmiAdiguzelProje.Interfaces
{
    public interface IJsonObjectSerializer<T>
    {
        public T DeserializeObject(object value);
    }
}
