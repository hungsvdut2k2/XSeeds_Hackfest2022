namespace API.Models.ModelDTOs
{
    public class AccountDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Full_Name { get; set; }
        public string Katakana_Name { get; set;}
        public int University_Id { get; set; }
              
    }
}
