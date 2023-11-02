using System.Security.Cryptography;

public class RSAExample
{
    public static void Main(string[] args)
    {
        try
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                RSAParameters publicKey = rsa.ExportParameters(false); // Public key
                RSAParameters privateKey = rsa.ExportParameters(true);  // Private key

                Console.WriteLine("Enter the data to be encrypted: " );
                string originalData = Console.ReadLine();
                byte[] dataToEncrypt = System.Text.Encoding.UTF8.GetBytes(originalData);

                byte[] encryptedData = Encrypt(dataToEncrypt, publicKey);

                byte[] decryptedData = Decrypt(encryptedData, privateKey);

                string decryptedText = System.Text.Encoding.UTF8.GetString(decryptedData);

                Console.WriteLine("Original Data: " + originalData);
                Console.WriteLine("Encrypted Data : " + Convert.ToBase64String(encryptedData));
                Console.WriteLine("Decrypted Data: " + decryptedText);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }

    public static byte[] Encrypt(byte[] dataToEncrypt, RSAParameters publicKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(publicKey);
            return rsa.Encrypt(dataToEncrypt, false);
        }
    }

    public static byte[] Decrypt(byte[] encryptedData, RSAParameters privateKey)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportParameters(privateKey);
            return rsa.Decrypt(encryptedData, false);
        }
    }
}

