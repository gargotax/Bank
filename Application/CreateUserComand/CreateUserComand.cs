namespace Application.CreateUserComand
{
    public class CreateUserComand
    {
        public string Name {  get;}
        public int NhsNumber { get;}
        public CreateUserComand(string name, int nhsNumber)
        {
            Name = name;
            NhsNumber = nhsNumber;
        }
    }
}
