using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDTOs
{
    public class CourseDTO
    {
        public int Course_Id { get; set; }
        public string Course_Name { get; set; }
        public string Level { get; set; }
        public int Max_Bonus_Star { get; set; }
        public int EstimateDay { get; set; }
        public int LearningPathId { get; set; }
    }
}
