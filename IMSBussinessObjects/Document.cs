using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long DocumentId { get; set; }

        [MaxLength(50)]
        public string DocumentName { get; set; }

        public int InternId { get; set; }

        [MaxLength(500)]
        public string DocumentUrl { get; set; }

        [ForeignKey("InternId")]
        public Intern Intern { get; set; }
    }
}
