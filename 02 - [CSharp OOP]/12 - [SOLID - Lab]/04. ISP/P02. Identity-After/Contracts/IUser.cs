namespace P02._Identity_After.Contracts
{
    public interface IUser
    {
        string Email { get; }

        string PasswordHash { get; }
    }
}
