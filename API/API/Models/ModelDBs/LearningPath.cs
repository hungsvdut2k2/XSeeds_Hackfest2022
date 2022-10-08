using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class LearningPath
    {
        [Key]
        public int Path_Id { get; set; }
        public string Path_Name { get; set; }
        public virtual ICollection<Course> Course { get; set; }
    }
}
