namespace ConJob.Domain.Encryption
{
    public interface IEncryption <T>
    {
        public string Encrypt(T data);
        public T Decrypt(string data);
    }
}
