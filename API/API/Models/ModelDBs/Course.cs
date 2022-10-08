using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Unit> Units { get; set; }

    }

}
