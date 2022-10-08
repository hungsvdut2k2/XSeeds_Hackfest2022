using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class VideoUnit
    {
        [Key]
        [ForeignKey("Unit")]
        public int Unit_Id { get; set; }
        public int Star { get; set; }
        public string VideoUrl { get; set; }
        public virtual Unit Unit { get; set; }

    }
}
