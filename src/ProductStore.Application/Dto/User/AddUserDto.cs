namespace ProductStore.Application.Dto.Category;

public class AddUserDto
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
    public string CountryCode { get; set; }
}