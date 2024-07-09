using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Intern")]
    public class Interns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternId { get; set; }

        [MaxLength(50)]
        public string? FullName { get; set; }
        
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        
        public string PersonalId { get; set; }
        
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MaxLength(100)]
        public string Uni { get; set; }

        [MaxLength(100)]
        public string Grade { get; set; }

        [MaxLength(255)]
        public string Gpa { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTimeOffset? InternshipStartingDate { get; set; }
        public DateTimeOffset? InternshipEndingDate { get; set; }
        
        public string PhotoUrl { get; set; }

        public string CvUrl { get; set; }
        
        public string OverallSuccess { get; set; }

       
    }
}