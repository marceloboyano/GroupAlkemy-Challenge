﻿using AlkemyWallet.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models;

public class AccountForShowDTO
{
    public int Id { get; set; }
    public float Money { get; set; } = 0f;

    public int User_id { get; set; } = 0;
}

public class AccountForShowWithDetailsDTO
{
    public int Id { get; set; }
    public float Money { get; set; } 
    public DateTime CreationDate { get; set; }
    public int User_id { get; set; }
    public bool IsBlocked { get; set; }
  
  

}

public class AccountForCreationDTO
{
    [Required(ErrorMessage = "A Creation Date is Required")]
    public DateTime CreationDate { get; set; }

    [Required(ErrorMessage = "An Amount its Required")]
    public float Money { get; set; }

    [Required(ErrorMessage = "User Id is Required")]
    public int User_id { get; set; }
}

public class AccountForUpdateDTO
{
    [Required(ErrorMessage = "A Creation Date is Required")]
    public DateTime? CreationDate { get; set; }

    [Required(ErrorMessage = "An Amount its Required")]
    public float? Money { get; set; }

    [Required(ErrorMessage = "User Id is Required")]
    public int? User_id { get; set; }
}