using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Exam
    {
        [Key]
        public int Exam_Id { get; set; }

        [ForeignKey("Unit")]
        public int Unit_Id { get; set; } 
        public virtual Unit Unit { get; set; }
        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<ExamStudent> ExamStudents { get; set; }
    }
}
