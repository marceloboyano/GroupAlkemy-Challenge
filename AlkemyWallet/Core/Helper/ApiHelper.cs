using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace AlkemyWallet.Core.Helper;

public static class ApiHelper
{
    public static bool IsEmailValid(string email)
    {
        Regex regex = new("^[_a-z0-9A-Z]+(\\.[_a-z0-9A-Z]+)*@[a-zA-Z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-zA-Z]{2,15})$");
        if (regex.IsMatch(email))
            return true;
        return false;
    }
    public static string GetIpAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
            if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                return ip.ToString();
        return string.Empty;
    }
   
}

