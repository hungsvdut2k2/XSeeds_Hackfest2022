using System.ComponentModel.DataAnnotations;

namespace API.Models.ModelDTOs
{
    public class StudentDTO
    {
        public int Student_Id { get; set; }
        public string VietnameseName { get; set; }
        public string KatakanaName { get; set; }

    }
}
