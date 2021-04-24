namespace ApplicationCore.ServiceInterfaces
{
    public interface ICryptoService
    {
        //byte[][] GetEncryption(string password, byte[] salt = null);
        string HashPassword(string password);
    }
}