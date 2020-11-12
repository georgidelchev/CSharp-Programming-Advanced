namespace P02._Identity_After.Contracts
{
    public interface IAccountManager
    {
        void ChangePassword(string oldPass, string newPass);
    }
}
