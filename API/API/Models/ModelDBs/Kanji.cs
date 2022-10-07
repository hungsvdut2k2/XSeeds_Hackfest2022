using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models.ModelDBs
{
    public class Kanji
    {
        [Key]
        [ForeignKey("Word")]
        public int Word_Id { get; set; }
        public string Word_Kanji { get; set; }
        public string Kunyomi { get; set; }
        public string Onyomi { get; set; }

        public string HanViet { get;set; }

        public virtual Word Word { get; set; }


    }
}
