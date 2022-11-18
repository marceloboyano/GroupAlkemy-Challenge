namespace AlkemyWallet.Core.Helper;

public class Response<T>
{
    public Response()
    {
    }

    public Response(T data, string message = null)
    {
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(T data, bool unsuccessful = false, string message = null)
    {
        Succeeded = unsuccessful;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Succeeded = false;
        Message = message;
    }

    public bool Succeeded { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }
    public T Data { get; set; }
}