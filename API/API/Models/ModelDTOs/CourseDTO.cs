using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDTOs
{
    public class CourseDTO
    {
        public int Course_Id { get; set; }
        public string Course_Name { get; set; }
        public string Type { get; set; }
        public int Max_Bonus_Star { get; set; }
        public DateTime EstimateDay { get; set; }
    }
}
