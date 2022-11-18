using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models;

[Table("FixedTermDepositDTO")]
public class FixedTermDepositDTO
{
    [Key] public int Id { get; set; }


    [Required(ErrorMessage = "el campo es requerido")]
    public int User_id { get; set; }

    [ForeignKey("User_id")] public UserDTO? User { get; set; }


    [Required(ErrorMessage = "el campo es requerido")]
    public int Account_id { get; set; }

    [ForeignKey("Account_id")] public AccountForShowDTO? Account { get; set; }


    [Required(ErrorMessage = "el campo es requerido")]
    public float Amount { get; set; } = 0f;


    [Required(ErrorMessage = "el campo es requerido")]
    public DateTime Creation_date { get; set; }


    [Required(ErrorMessage = "el campo es requerido")]
    public DateTime Closing_date { get; set; }
}

public class FixedTermDepositForShowDTO
{
    public int Id { get; set; }
    public int User_id { get; set; } = 0;
    public int Account_id { get; set; } = 0;
    public float Amount { get; set; } = 0;
    public DateTime Creation_date { get; set; }
    public DateTime Closing_date { get; set; }
}

public class DepositForShowDTO
{
    public int Id { get; set; }
    public int User_id { get; set; } = 0;
    public int Account_id { get; set; } = 0;
    public DateTime Creation_date { get; set; }
}

public class DepositForUpdateDTO
{
    public int? User_id { get; set; } = 0;
    public int? Account_id { get; set; } = 0;
    public float? Amount { get; set; } = 0;
    public DateTime? Creation_date { get; set; }
    public DateTime? Closing_date { get; set; }
}

public class DepositForCreationDTO
{
    [Required(ErrorMessage = "User Id is Required")]
    public int? User_id { get; set; } = 0;

    [Required(ErrorMessage = "Account Id is Required")]
    public int? Account_id { get; set; } = 0;

    [Column(TypeName = "decimal(18,4)")]
    [Required(ErrorMessage = "An Amount its Required")]
    public float? Amount { get; set; } = 0;

    [Required(ErrorMessage = "A Closing Date is Required")]
    public DateTime? Closing_date { get; set; }
}