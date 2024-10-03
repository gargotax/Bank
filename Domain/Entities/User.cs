namespace Domain.Entities
{
    public class User
    {
        public Guid IdUser { get;}
        public string Name { get;}
        public string NhsNumber { get;}
        public User(Guid idUser, string name, string nhsNumber)
        {
            IdUser = idUser;
            Name = name;
            NhsNumber = nhsNumber;
        }
    }
}
