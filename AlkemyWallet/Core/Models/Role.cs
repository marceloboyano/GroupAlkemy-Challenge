using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public string Name { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]

        public string Description { get; set; }
        
        public ICollection<User> User { get; set; }
    }
}
