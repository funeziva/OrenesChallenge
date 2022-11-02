namespace Domain.Users.Exceptions
{
    public class UserNotFound : Exception
    {
        public UserNotFound(string name) : base($"The user with name {name} is not found") { }
    }
}
