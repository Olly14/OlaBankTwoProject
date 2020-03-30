//namespace Bank.Data.Security.Encryption
//{
//    public interface IUriParameterSecurity
//    {
//        /// <summary>
//        /// Encrypts the dynamic list of properties that form the composite key
//        /// </summary>
//        /// <param name="key"></param>
//        /// <returns>Base64 Encoded Encrypted JSON string</returns>
//        string Encrypt(dynamic key);

//        /// <summary>
//        /// Decrypts the Encrypted JSON String back to the Keys' Object
//        /// </summary>
//        /// <param name="compositeKey"></param>
//        /// <returns>Object</returns>
//        T Decrypt<T>(string compositeKey);
//    }
//}