namespace AlkemyWallet.Core.Helper.ExceptionGenerics;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string MessageProcessingHandler { get; set; }
    public string StackTrace { get; set; }
}