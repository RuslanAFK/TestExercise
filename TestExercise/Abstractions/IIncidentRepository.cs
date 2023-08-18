﻿using TestExercise.Domain.Models;

namespace TestExercise.Abstractions;

public interface IIncidentRepository
{
    Task<List<Incident>> GetAll();
    Task<Incident?> GetByName(string name);
    void Add(Incident incident);
    void Update(Incident incident);
    void Remove(Incident incident);
}