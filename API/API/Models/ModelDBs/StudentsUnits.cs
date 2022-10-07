using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class StudentsUnits
    {
        public int New_Unit_id { get; set; }
        public int New_Student_Id { get; set; }
        public bool Is_Done { get; set; }
    }
}
