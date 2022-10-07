using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Teacher
    {
        [ForeignKey("Account")]
        public int User_Id { get; set; }
        [Key]
        public int Teacher_Id { get; set; }
        public int University_Id { get; set; }
        public string Teacher_Name { get; set; }
        public string Katakana_Name { get; set; }

        //
        public virtual Account Account { get; set; }
        public virtual University University { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
