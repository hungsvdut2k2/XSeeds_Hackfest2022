using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class University
    {
        [Key]
        public int University_Id { get; set; }
        public string University_Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]

        public virtual ICollection<Student> Students { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]
        public virtual ICollection<Teacher> Teachers { get; set; }  
    }
}
