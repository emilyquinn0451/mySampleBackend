using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mySampleBackend.Constants;

namespace mySampleBackend.Infrastructure
{
    [Table("FLOOPS", Schema = "dbo")]
    public class FloopDbEntity
    { 
    public FloopDbEntity() {
            floop_name = FloopConstants.defaultFloopName;
            floop_safety_code = FloopConstants.floopSafetyCode1;
            floop_type_code = "Happy";
            floop_value = 13.37;
            floop_creation_date = DateTime.Now;

     }
        //Floop ID. Primary key automatically generated
        [Key] 
        public int floop_id { get; set; }
        
        //Floop Type Code.
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string floop_type_code { get; set; }
        //Floop Safety Code.
        [Column(TypeName = "VARCHAR")]
        [MaxLength(10)]
        public string floop_safety_code { get; set; }
        //Floop Name. Defaults to "Kevin"
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string floop_name { get; set; }
        //Floop Value. Defaults to "0"
        [Column(TypeName = "DECIMAL")]
        public Double floop_value { get; set; }
        //Date Floop Created
        [Column(TypeName = "SMALLDATETIME")]
        public DateTime floop_creation_date { get; set; }

    }
}

