using System.Collections.ObjectModel;

namespace TestExercise.Domain.Models;

public class Incident
{
    public string IncidentName { get; set; }
    public string Description { get; set; }
    public ICollection<Account> Accounts { get; set; }

    public Incident()
    {
        Accounts = new Collection<Account>();
    }
}