using IsmailHilmiAdiguzelProje.Models;
using System.Text.Json.Serialization;

namespace IsmailHilmiAdiguzelProje.Interfaces
{
    public interface IJsonResponseGetter<T>
    {
        Dictionary<string, object>? Request { get; set; }
        T? Response { get; set; }
    }

    public interface IJsonDataObjectGetter<T> 
    {
        public int Status { get; set; }
        public int HttpStatus { get; set; }
        public T? Data { get; set; }
        public List<object>? Errors { get; set; }
        public object? ErrorMessage { get; set; }
    }
}
