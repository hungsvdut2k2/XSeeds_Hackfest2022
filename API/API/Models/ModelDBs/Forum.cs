using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class Forum
    {
        [Key]
        public int Forum_Id { get; set; }
        public string Forum_Name { get; set; }
        public virtual ICollection<ForumThread> ForumThreads { get; set; }
    }
}
