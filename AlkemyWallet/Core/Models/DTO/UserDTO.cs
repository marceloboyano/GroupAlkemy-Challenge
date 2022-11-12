using AlkemyWallet.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models;

public class UserDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "el campo es requerido")]
    public string First_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Last_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public int Rol_id { get; set; }
}

public class UserByIdDTO
{
    public int Id { get; set; }

    [Required(ErrorMessage = "el campo es requerido")]
    public string First_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Last_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public int Points { get; set; } = 0;

    [Required(ErrorMessage = "el campo es requerido")]
    public int Rol_id { get; set; } = 0;

    [ForeignKey("Rol_id")] public Role? Role { get; set; }
}

public class UserForCreatoionDto
{
    [Required(ErrorMessage = "el campo es requerido")]
    public string First_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Last_name { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "el campo es requerido")]
    [MaxLength(20)]
    public string Password { get; set; } = string.Empty;


    [Required(ErrorMessage = "el campo es requerido")]
    public int Points { get; set; }
}

public class UserForUpdateDto
{
    public string? First_name { get; set; }
    public string? Last_name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? Points { get; set; }

    public int? Rol_id { get; set; }
}