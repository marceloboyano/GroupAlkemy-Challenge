using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Helper;

public class Response<T>
{
    public Response()
    {
        Errors = new List<string>();
    }

    public Response(T data, string? message = null)
    {
        Errors = new List<string>();
        Succeeded = true;
        Message = message;
        Data = data;
    }

    public Response(T data, bool unsuccessful = false, string? message = null)
    {
        Errors = new List<string>();
        Succeeded = unsuccessful;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Errors = new List<string>();
        Succeeded = false;
        Message = message;
    }

    public bool Succeeded { get; set; }
    public string? Message { get; set; }
    public List<string> Errors { get; set; }
    public T? Data { get; set; }
}