using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDTOs
{
    public class UnitDTO
    {
        public int Unit_Id { get; set; }
        public int Course_Id { get; set; }
        public int Star { get; set; }
        public int Teacher_Id { get; set; }
        
    }
}
