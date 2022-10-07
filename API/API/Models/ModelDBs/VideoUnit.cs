using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class VideoUnit
    {
        [Key]
        public int Unit_Id { get; set; }
        public int Star { get; set; }
        public string VideoUrl { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
