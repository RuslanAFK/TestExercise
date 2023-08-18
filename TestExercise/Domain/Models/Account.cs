using System.Collections.ObjectModel;

namespace TestExercise.Domain.Models;

public class Account
{
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    public string? IncidentName { get; set; }
    public ICollection<Contact> Contacts { get; set; }

    public Account()
    {
        Contacts = new Collection<Contact>();
    }
}