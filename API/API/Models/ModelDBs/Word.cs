using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class Word
    {
        [Key]
        public int Word_Id { get; set; }
        public int Unit_Id { get; set; }
        public int Student_Id { get; set; }
        public string Type { get; set; } 

        public virtual WordUnit WordUnit { get; set; }

    }
}
