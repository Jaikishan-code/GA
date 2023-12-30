using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GA.Entity.Student
{
    [Table("STD_UNQSERIES", Schema = "STD")]

    public class STD_UNQSERIES
    {
        [Key]
        public int UNQ_ID { get; set; }

        public Guid UNQ_STDCLID { get; set; }

        public string UNQ_CODE { get; set; }

        public int UNQ_SERIES { get; set; }


        [ForeignKey("UNQ_STDCLID")]
        public virtual GA_STDCLASS STD_CLASS { get; set; }
    }
}
