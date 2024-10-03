namespace Application.UpdateUserComand
{
    public interface IUpdateUserComandHandler
    {
        Task HandleAsync(UpdateUserComand comand, CancellationToken cancellationToken);
    }
}
