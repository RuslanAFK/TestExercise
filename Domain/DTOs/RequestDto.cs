using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs;

public class RequestDto
{
    public string AccountName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string IncidentDescription { get; set; }

}
