using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string First_name { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Last_name { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Password { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public int Points { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public int Rol_id { get; set; }

        [ForeignKey("Rol_id")]
        public Role Role { get; set; }


        public ICollection<Account> Account {get; set;}

        public ICollection<Transaction> Transaction { get; set; }

        public ICollection<FixedTermDeposit> FixedTermDeposit { get; set; }

    }
}
