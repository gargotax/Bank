namespace Application.AccountComands
{
    public class CreateAccountComand
    {
        public Guid Id { get;}
        public Guid Iduser { get;}
        public decimal Balance { get;}
        public decimal Overdraft { get;}
        public CreateAccountComand(Guid id, Guid idUser, decimal balance, decimal overdraft)
        {
            Id = id;
            Iduser = idUser;
            Balance = balance;
            Overdraft = overdraft;

        }
    }
}
