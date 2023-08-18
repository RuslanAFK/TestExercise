namespace Domain.Models;

public class Contact
{
    public int ContactId { get; set; }
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Email { get; set; }
    public int? AccountId { get; set; }
}