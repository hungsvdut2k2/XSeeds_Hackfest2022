using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class GrammarUnit
    {
        [Key]
        [ForeignKey("Unit")]
        public int Unit_Id { get; set; }
        public string Unit_Name { get; set; }   
        public string Content { get; set; }

        public virtual Unit Unit { get; set; }

    }
}
