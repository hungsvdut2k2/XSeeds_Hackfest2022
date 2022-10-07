using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class GrammarUnit
    {
        [Key]
        public int Unit_Id { get; set; }
        public string Unit_Name { get; set; }   
        public string Content { get; set; }

        public virtual Unit Unit { get; set; }

    }
}
