using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{
    [Table("RoleDTO")]
    public class RoleDTO
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]
        public string Name { get; set; }


        [Required(ErrorMessage = "el campo es requerido")]

        public string Description { get; set; }
        
        public ICollection<UserDTO> User { get; set; }
    }
}
