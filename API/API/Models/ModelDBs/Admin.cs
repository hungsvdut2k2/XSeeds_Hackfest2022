using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Admin
    {
        [ForeignKey("Account")]
        [Key]
        public int User_Id { get; set; }
 
        public virtual Account Account { get; set; }

    }
}