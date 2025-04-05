using System.ComponentModel.DataAnnotations;

namespace Cifcisinden.WebApi.Models
{
    public class UpdateAdvertRequest
    {
        

        [Required]
        public string Description { get; set; }
        
        

    }
}
