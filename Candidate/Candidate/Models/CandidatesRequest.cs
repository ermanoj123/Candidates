using System.ComponentModel.DataAnnotations;

namespace Candidate.Models
{
    public class CandidatesRequest
    {
        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string LastName { get; set; } = null!;
        public int? PhoneNumber { get; set; } 

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        public string Email { get; set; } = null!;

        [StringLength(20, ErrorMessage = "Preferred Call Time cannot exceed 20 characters.")]
        public string? PreferredCallTime { get; set; } 


        [StringLength(200, ErrorMessage = "LinkedIn Profile URL cannot exceed 200 characters.")]
        public string? LinkedInProfileUrl { get; set; }


        [StringLength(200, ErrorMessage = "GitHub Profile URL cannot exceed 200 characters.")]
        public string? GitHubProfileUrl { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Free Text Comment cannot exceed 500 characters.")]
        public string FreeTextComment { get; set; } = null!;
    }
}
