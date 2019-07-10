namespace Emerging.Account.WebApi.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AccountPostRequestBody
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(254)]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Role { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
