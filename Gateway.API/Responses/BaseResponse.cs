namespace Gateway.API.Responses
{
    public class BaseResponse<T> where T : class
    {
        public T? Result { get; set; }
        public bool HasSucceeded { get; set; }
    }
}
