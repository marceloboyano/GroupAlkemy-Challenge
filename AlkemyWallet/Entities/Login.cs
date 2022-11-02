using System.ComponentModel.DataAnnotations;

namespace AlkemyWallet.Entities
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
