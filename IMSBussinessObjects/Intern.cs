using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Interns")]
    public class Intern
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InternId { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string PersonalId { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string Uni { get; set; }

        [MaxLength(150)]
        public string Major { get; set; }

        public int? Grade { get; set; }
        public int? Gpa { get; set; }
        public int? TeamId { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime InternshipStartingDate { get; set; }
        public DateTime InternshipEndingDate { get; set; }

        [MaxLength(500)]
        public string CvUrl { get; set; }

        [MaxLength(500)]
        public string PhotoUrl { get; set; }

        public int? OverallSuccess { get; set; }
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        [Required]
        [MaxLength(20)] // Adjust max length as needed
        public string Status { get; set; } // "approved", "waiting", "rejected"
    }
}
