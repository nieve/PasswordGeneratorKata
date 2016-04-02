namespace TemporaryPassword
{
    public interface IPasswordGenerator
    {
        string Create(int id);
    }

    public class PasswordGenerator : IPasswordGenerator
    {
        public string Create(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
