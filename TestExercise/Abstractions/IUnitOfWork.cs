namespace TestExercise.Abstractions;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
