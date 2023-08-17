﻿namespace TestExercise.Domain.Models;

public class Account
{
    public int AccountId { get; set; }
    public string AccountName { get; set; }
    public string IncidentName { get; set; }
    public Incident Incident { get; set; }
    public ICollection<Contact> Contacts { get; set; }
}