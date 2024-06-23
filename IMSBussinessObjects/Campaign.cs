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

        [Required]
        [StringLength(255)]
        public string CampaignName { get; set; }

        public string Description { get; set; }

        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }

        [StringLength(255)]
        public string Major { get; set; }

        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CreateBy")]
        public User CreateUser { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}