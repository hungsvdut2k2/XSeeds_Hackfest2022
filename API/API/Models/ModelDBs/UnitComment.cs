using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDBs
{
    public class UnitComment
    {
        [Key]
        public int Comment_Id { get; set; }
        public int Unit_Id { get; set; }
        public int User_Id { get; set; }

        public virtual Unit Unit { get; set; }

    }
}
