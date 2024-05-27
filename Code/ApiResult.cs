using System.Net;

namespace Online_Pet_Store_Example;

public class ApiResult<T>
{
    public HttpStatusCode HttpStatusCode = HttpStatusCode.NotImplemented;
    public string Message;
    public IEnumerable<T> Result;
    public bool Success = false;
}

public class ApiResult : ApiResult<object>;