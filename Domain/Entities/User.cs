namespace Domain.Entities
{
    public class User
    {
        public Guid IdUser { get;}
        public string Name { get;}
        public User(Guid idUser, string name)
        {
            IdUser = idUser;
            Name = name;
        }
    }
}
