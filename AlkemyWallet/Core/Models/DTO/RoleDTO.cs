using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models;

[Table("RoleDTO")]
public class RolesDTO
{
    [Key] public int Id { get; set; }


    [Required(ErrorMessage = "el campo es requerido")]
    public string Name { get; set; } = string.Empty;


    [Required(ErrorMessage = "el campo es requerido")]
    public string Description { get; set; } = string.Empty;
}

public class RoleDTO
{
    [Required(ErrorMessage = "el campo es requerido")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Description { get; set; } = string.Empty;
}

public class RoleForUpdateDTO
{
    [StringLength(20, MinimumLength = 2)] public string Name { get; set; } = string.Empty;

    [StringLength(50, MinimumLength = 2)] public string Description { get; set; } = string.Empty;
}