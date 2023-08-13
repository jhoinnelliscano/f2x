
namespace F2x.EntityDomain.Objects
{
    public class ServiceResponseObject<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public ServiceResponseObject() { }
        public ServiceResponseObject(int statusCode, string message, T result) 
        {
            StatusCode = statusCode;
            Message = message;
            Result = result;
        }
    }
}
