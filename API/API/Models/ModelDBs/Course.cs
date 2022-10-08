using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models.ModelDBs
{
    public class Course
    {
        [Key]
        public int Course_Id { get; set; }

        public string Course_Name { get; set; }
        public string Level { get; set; }
        public int Max_Bonus_Star { get; set; }
        public int Estimate_Day { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]

        [ForeignKey("LearningPath")]
        public int Learning_Path_Id { get; set; }
        public LearningPath LearningPath { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Unit> Units { get; set; }

    }

}
