using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Document")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }

        [MaxLength(255)]
        public string? DocumentName { get; set; }

        public string DocumentUrl { get; set; }
        
        [ForeignKey("InternId")]
        public int TeamId { get; set; }
      

       
    }
}
