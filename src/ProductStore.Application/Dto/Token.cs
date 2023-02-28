namespace ProductStore.Application.Dto;

public class Token
{
    public string AccessToken { get; set; }
    public DateTime Expiration { get; set; }
}