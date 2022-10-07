namespace API.Models.ModelDTOs
{
    public class ResetPasswordDTO
    {
        public string Email { get; set; }
        public string ResetPasswordToken { get; set; }
        public string NewPassword { get; set; }
    }
}
