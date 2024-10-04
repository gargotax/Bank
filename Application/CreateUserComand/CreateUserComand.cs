namespace Application.CreateUserComand
{
    public class CreateUserComand
    {
        public string Name {  get;}
        public string NhsNumber { get;}
        public CreateUserComand(string name, string nhsNumber)
        {
            Name = name;
            NhsNumber = nhsNumber;
        }
    }
}