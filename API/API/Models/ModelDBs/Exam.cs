using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Exam
    {
        [Key]
        public int Exam_Id { get; set; }
        public int? Sudent_Id { get; set; }

        [ForeignKey("Unit")]
        public int Unit_Id { get; set; } 
        public string Exam_Name { get; set; }
        public string Question {get; set; }
        
        public string  AnswerA { get; set; }
        public string  AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string Answer { get; set; }

        public virtual Unit Unit { get; set; }

    }
}
