using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        public string Course_Name { get; set; }
        public string Type { get; set; }
        public int Max_Bonus_Star { get; set; }
        public DateTime EstimateDay { get; set; }
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }

        public virtual ICollection<Unit> Units { get; set; }

    }

}
