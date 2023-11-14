namespace PracticeAPI.Models.Data.ResponseDTO
{
    public class LoginResponseDTO
    {
        public CustomerResponseDTO CustomerResponseDTO { get; set; }

        public string Token { get; set; }
    }
}
