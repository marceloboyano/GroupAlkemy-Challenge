using Microsoft.AspNetCore.Identity;

namespace AlkemyWallet.Entities;

public class ApplicationUser : IdentityUser
{
    public int RolId { get; set; }
}