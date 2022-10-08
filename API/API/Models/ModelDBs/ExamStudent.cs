using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class ExamStudent
    {

        [Key]
        public int ExemStudent_Id { get; set; }
        public int Student_Id { get; set; }
        public int Examp_Id { get; set; }

        public virtual Exam Exam { get; set; }
    }
}
