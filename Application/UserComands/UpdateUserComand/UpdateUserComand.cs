namespace Application.UserComands.UpdateUserComand
{
    public class UpdateUserComand
    {
        public Guid Id { get; }
        public string Name { get; }
        public UpdateUserComand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}