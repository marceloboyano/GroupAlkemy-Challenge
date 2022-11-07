using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AlkemyWallet.Entities;

namespace AlkemyWallet.Core.Models;


public class AccountForShowDTO
{
    public int Id { get; set; }      
    public float Money { get; set; } = 0f; 
    
    public int User_id { get; set; } = 0;
}

public class AccountForCreationDTO
{


    [Required(ErrorMessage = "A Creation Date is Required")]
    public DateTime CreationDate { get; set; }
    [Required(ErrorMessage = "An Amount its Required")]
    public float Money { get; set; }
    [Required(ErrorMessage = "Set The Account Status")]
    public bool IsBlocked { get; set; }
    [Required(ErrorMessage = "User Id is Required")]
    public int User_id { get; set; } 

  //  [ForeignKey("User_id")] public User? User { get; set; }
   

}

