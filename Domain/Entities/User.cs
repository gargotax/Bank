namespace Domain.Entities
{
    public class User
    {
        public Guid IdUser { get;}
        public string Name { get;}
        public int NhsNumber { get;}
        public User(Guid idUser, string name, int nhsNumber)
        {
            IdUser = idUser;
            Name = name;
            NhsNumber = nhsNumber;
        }
    }
}
