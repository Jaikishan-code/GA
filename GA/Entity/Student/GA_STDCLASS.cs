using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.Entity.Student
{
    [Table("GA_STDCLASS", Schema = "STD")]

    public class GA_STDCLASS
    {
        [Key]

        public Guid STD_CLID { get; set; }
        public int STD_ID { get; set; }

        public string STD_CLNAME { get; set; }
    }
}
