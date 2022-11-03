using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{

   
    public class CatalogueDTO
    {       
        public string Product_description { get; set; }       
        public string Image { get; set; }       
        public int Points { get; set; }
    }
}
