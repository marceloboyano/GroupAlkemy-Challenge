using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The First name should have at least 1 letter")]
        [MaxLength(100)]
        [MinLength(1)]
        public string First_name { get; set; }

        [MaxLength(100)]
        [MinLength(1)]
        [Required(ErrorMessage = "The Last name should have at least 1 letter")]
        public string Last_name { get; set; }

        [MaxLength(150)]
        [MinLength(7)]
        [Required(ErrorMessage = "The Email Should be Between 4 and 20 Characters")]
        public string Email { get; set; }

        [MaxLength(20)]
        [MinLength(4)]
        [Required(ErrorMessage = "The Password should be between 4 and 20 Characters ")]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required(ErrorMessage = "Insert the Value")]
        public int Points { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "A Role id its required")]
        public int Rol_id { get; set; }

        [ForeignKey("Rol_id")]
        public Role Role { get; set; }


        public ICollection<Account> Account { get; set; }

        public ICollection<Transaction> Transaction { get; set; }

        public ICollection<FixedTermDeposit> FixedTermDeposit { get; set; }

    }
}
