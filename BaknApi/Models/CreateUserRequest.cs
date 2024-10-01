using System.ComponentModel.DataAnnotations;

namespace BaknApi.Models
{
    public record CreateUserRequest(
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name can only contain letters, white spaces are not accepted")]
        string Name);
}
