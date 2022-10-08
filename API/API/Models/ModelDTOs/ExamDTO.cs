namespace API.Models.ModelDTOs
{
    public class ExamDTO
    {
        public int Unit_Id { get; set; }
        public string Exam_Name { get; set; }
        public string Question { get; set; }

        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string Answer { get; set; }

    }
}
