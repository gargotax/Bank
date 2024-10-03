namespace BaknApi.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NhsNumber { get; set; }
        public UserDto(Guid id, string name, string nhsNumber)
        {
            Id = id;
            Name = name;
            NhsNumber = nhsNumber;
        }
    }
}
