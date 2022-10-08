namespace API.Models.ModelDTOs
{
    public class QuestionDTOUpdate
    {
        public int Question_Id { get; set; }
        public string Content { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string Answer { get; set; }
    }
}
