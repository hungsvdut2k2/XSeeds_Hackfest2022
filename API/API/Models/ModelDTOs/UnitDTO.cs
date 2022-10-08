using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDTOs
{
    public class UnitDTO
    {
        public int Course_Id { get; set; }
        public string Unit_Name { get; set; }
        public int Star { get; set; }
        public int Teacher_Id { get; set; }
        public int Number { get; set; }
        public string Type { get; set; }
        public string? Content { get; set; }
        public string? VideoUrl { get; set; }
        
    }
}
