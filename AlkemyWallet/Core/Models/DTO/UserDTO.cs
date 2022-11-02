using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Models
{
    [Table("UserDTO")]
    public class UserDTO
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


        public ICollection<AccountDTO> Account {get; set;}

        public ICollection<TransactionDTO> Transaction { get; set; }

        public ICollection<FixedTermDepositDTO> FixedTermDeposit { get; set; }

    }
}
