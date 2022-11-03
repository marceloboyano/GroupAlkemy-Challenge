using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlkemyWallet.Core.Models
{

   
    public class CatalogueDTO
    {       
        public string Product_description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public int Points { get; set; }
    }
}
