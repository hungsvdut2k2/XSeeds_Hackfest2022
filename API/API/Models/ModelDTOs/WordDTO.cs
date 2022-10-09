namespace API.Models.ModelDTOs
{
    public class WordDTO
    {
        public int Unit_Id { get; set; }
       
        public string Type { get; set; }
        public string? Word_Kanji { get; set; }
        public string? Kunyomi { get; set; }
        public string? Onyomi { get; set; }  
        public string? HanViet { get; set; }

        public string? Word_tango { get; set; }
        public string? Pronounce { get; set; }
        public string? VietNamese_mean { get; set; }
    }
}
