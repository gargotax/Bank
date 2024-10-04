

namespace Application.AccountComands
{
    public interface ICreateAccountComandHandler
    {
        Task<Guid> HandleAsync(CreateAccountComand comand, CancellationToken cancellationToken);
    }
}
