using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class ForumThread
    {
        [Key]
        public int Thread_Id  { get; set; }
        public int Thread_Name { get; set; }
        [ForeignKey("Forum")]
        public int Forum_Id { get; set; }
        public Forum Forum { get; set; }
        [ForeignKey("Account")]
        public int Account_Id { get; set; }
        public virtual Account Account { get; set; }
    }
}
