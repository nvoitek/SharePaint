using System.ComponentModel.DataAnnotations;

namespace SharePaint.Models
{
    // TODO: Split model and entity
    // TODO: Add createdAt and updatedAt
    // TODO: Add signin with password hashing
    public class User : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
