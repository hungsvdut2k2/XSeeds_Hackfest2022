using API.Models.ModelDBs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Student
    {
        [ForeignKey("Account")]
        public int User_Id { get; set; }
        [Key]
        public int Student_Id { get; set; }
        public int University_Id { get; set; }
        public string VietnameseName { get; set; }
        public string KatakanaName { get; set; }

        public virtual University University { get; set; }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual Account Account { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<StudentsCourses> StudentsCourses { get; set; }
    }
}
