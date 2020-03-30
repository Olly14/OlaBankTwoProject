namespace Bank.Data.Security.Helpers
{
    public interface IPasswordBaseKeyDerivationFunction
    {
        byte[] GenerateSalt();

        byte[] HashPassword(byte[] password, byte[] salt, int rounds);

        string StringHashPassword(byte[] password, byte[] salt, int rounds);
    }
}