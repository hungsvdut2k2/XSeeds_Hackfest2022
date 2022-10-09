using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class Tango
    {
        [Key]
        [ForeignKey("Word")]
        public int Word_Id { get; set; }
        public string Word_Tango { get; set; }
        public string Pronounce { get; set; }
        public string Vietnamese_mean { get; set; }
        public virtual Word Word { get; set; }

    }
}
