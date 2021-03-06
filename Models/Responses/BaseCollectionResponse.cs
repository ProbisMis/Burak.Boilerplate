using System.Collections.Generic;

namespace Burak.Boilerplate.Models.Responses
{
    public abstract class BaseCollectionResponse<T>
    {
        public int TotalCount { get; set; }
        public List<T> Data { get; set; }
    }
}