using System.ComponentModel.DataAnnotations;

namespace AlkemyWallet.Core.Models;

public class TransactionDTO
{
    public int? Transaction_id { get; set; }


    [Required(ErrorMessage = "Amount es requerido")]
    public int Amount { get; set; }

    [Required(ErrorMessage = "Concept es requerido")]
    public string? Concept { get; set; }

    [Required(ErrorMessage = "Date es requerido")]
    public DateTime Date { get; set; }

    [Required(ErrorMessage = "Type es requerido")]
    public string? Type { get; set; }

    [Required(ErrorMessage = "User_id es requerido")]
    public int User_id { get; set; }

    [Required(ErrorMessage = "Account_id es requerido")]

    public int Account_id { get; set; }
}