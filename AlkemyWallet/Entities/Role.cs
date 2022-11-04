using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Entities
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public string Name { get; set; } = string.Empty;


        [Required(ErrorMessage = "el campo es requerido")]

        public string Description { get; set; } = string.Empty;

        public ICollection<User>? User { get; set; }
    }
}
