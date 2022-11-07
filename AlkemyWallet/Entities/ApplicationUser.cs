using Microsoft.AspNetCore.Identity;


    public class ApplicationUser : IdentityUser
    {
        public int RolId { get; set; }
    }

