using System.Net;
using System.Net.Sockets;

namespace AlkemyWallet.Core.Helper;

public class ApiHelper
{
    public static string GetIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
            if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                return ip.ToString();
        return string.Empty;
    }
}