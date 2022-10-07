using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class WordUnit
    {
        [Key]
        public int Unit_Id {get; set;}
        public string Unit_Name {get; set;}
        public int Star { get; set;}

        public virtual Unit Unit { get; set;}
        public virtual ICollection<Word> Word { get; set;}
    }
}
