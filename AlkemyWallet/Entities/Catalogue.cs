using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities
{

    [Table("Catalogue")]
    public class Catalogue
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Product_description { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public string Image { get; set; }

        [Required(ErrorMessage = "el campo es requerido")]
        public int Points { get; set; }
    }
}
