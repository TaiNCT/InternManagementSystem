using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMSBussinessObjects
{
    [Table("Documents")]
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentId { get; set; }
        [MaxLength(100)]
        public string DocumentName { get; set; }
        [MaxLength(100)]
        public string DocumentType { get; set; }
        [MaxLength]
        public byte[] DocumentData { get; set; }
    }
}
