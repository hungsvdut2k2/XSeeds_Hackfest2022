using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDTOs
{
    public class UnitDTO
    {
        public int Course_Id { get; set; }
        public int Star { get; set; }
        public int Teacher_Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        
    }
}
