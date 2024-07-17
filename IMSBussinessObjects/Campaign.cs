using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Campaigns")]
    public class Campaign
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CampaignId { get; set; }
        public string Tittle { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        public string? Progress { get; set; }
        public byte[]? PictureUrl { get; set; }

        [MaxLength(20)]
        public string? Status { get; set; }


        public int TeamId { get; set; }
        [ForeignKey("TeamId")]
        public Team? Team { get; set; }

    }
}
