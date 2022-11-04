using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities
{
    [Table("Transaction")]
    public class Transaction
    {
        [Key]
        public int Transaction_id { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Concept { get; set; } = string.Empty;

        [Required(ErrorMessage = "el campo es requerido")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Type { get; set; }= string.Empty;

        [Required(ErrorMessage = "el campo es requerido")]
        public int User_id { get; set; }

        [ForeignKey("User_id")]
        public User? User { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]

        public int Account_id { get; set; }
        [ForeignKey("Account_id")]

        public Account? Account { get; set; }
    }
}
