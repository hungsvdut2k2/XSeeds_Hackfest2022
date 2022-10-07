using API.Models.ModelDBs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Student
    {
        [ForeignKey("Account")]
        public int User_Id { get; set; }
        [Key]
        public int Student_Id { get; set; }
        public int University_Id { get; set; }
        public string VietnameseName { get; set; }
        public string KatakanaName { get; set; }

        public virtual University University { get; set; }
        public virtual Account Account { get; set; }

        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }
        public virtual ICollection<Word> Words { get; set; }
    }
}
