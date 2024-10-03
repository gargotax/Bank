using System.ComponentModel.DataAnnotations;

namespace BaknApi.Models
{
    public record CreateUserRequest(
     [Required]
    [RegularExpression(@"^[a-zA-Z -]+$", ErrorMessage = "Name can only contain letters and spaces")]
    string Name,

     [Required]
    [RegularExpression(@"^\d{15}$", ErrorMessage = "NhsNumber must be exactly 15 digits")]
    string NhsNumber);

}
