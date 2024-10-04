namespace Application.UserComands.UpdateUserComand
{
    public interface IUpdateUserComandHandler
    {
        Task HandleAsync(UpdateUserComand comand, CancellationToken cancellationToken);
    }
}
