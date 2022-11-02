using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AlkemyWallet.Core.Models
{
    [Table("Account")]
    public class Account
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public DateTime CreationDate { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public float Money { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]

        public bool IsBlocked { get; set; }

        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public User User { get; set; }

        public ICollection<FixedTermDeposit> FixedTermDeposit { get; set; }
    }
}