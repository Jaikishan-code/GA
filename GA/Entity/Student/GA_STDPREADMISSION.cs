using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GA.Entity.Student
{
    [Table("GA_STDPREADMISSION", Schema = "STD")]

    public class GA_STDPREADMISSION
    {
        [Key]
        public int STD_ID { get; set; }

        public string STD_CLASS { get; set; }

        public string STD_UNIQUECODE { get; set; }

        public string STD_FNAME { get; set; }

        public string STD_LNAME { get; set; }

        public string STD_FANAME { get; set; }

        public string STD_MOBILENO { get; set; }

        public decimal STD_AFEES { get; set; }

        public int STD_STSID { get; set; }

        public string STD_MEDIUM { get; set; }
    }
}
