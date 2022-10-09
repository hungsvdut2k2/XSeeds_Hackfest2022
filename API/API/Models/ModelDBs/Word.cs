using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Word
    {
        [Key]
        public int Word_Id { get; set; }
        [ForeignKey("WordUnit")]
        public int Unit_Id { get; set; }
        public string Type { get; set; } 

        public virtual WordUnit WordUnit { get; set; }

    }
}
