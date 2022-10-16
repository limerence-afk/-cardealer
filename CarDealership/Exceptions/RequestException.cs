namespace CarDealership.Exceptions;

[Serializable]
public class RequestException : Exception
{
    public RequestException(string message, int statusCode) : base(message)
    {
        StatusCode = statusCode;
    }

    public RequestException(string message, int statusCode, Exception inner) : base(message, inner)
    {
        StatusCode = statusCode;
    }

    public int StatusCode { get; private set; }
}