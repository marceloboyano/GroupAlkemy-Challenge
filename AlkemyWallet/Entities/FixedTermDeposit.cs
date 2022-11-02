using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities
{

    [Table("FixedTermDeposit")]
    public class FixedTermDeposit
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public int User_id { get; set; }
        [ForeignKey("User_id")]
        public User User { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public int Account_id { get; set; }
        [ForeignKey("Account_id")]
        public Account Account { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public float Amount { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public DateTime Creation_date { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public DateTime Closing_date { get; set; }

    }
}
