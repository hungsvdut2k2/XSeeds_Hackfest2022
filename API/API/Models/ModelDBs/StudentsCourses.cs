using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class StudentsCourses
    {
        [ForeignKey("Student")]
        public int Student_Id { get; set; }
        public virtual Student Student { get; set; }
        [ForeignKey("Course")]
        public int Course_Id { get; set; }
        public virtual Course Course { get; set; }

        public int Star_Get_From_Course { get; set; }
        public DateTime Start_At { get; set; }
        public DateTime? Finish_At { get; set; }
        
        


    }
}
