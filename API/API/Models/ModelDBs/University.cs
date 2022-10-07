using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class University
    {
        [Key]
        public int University_Id { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }  
    }
}
