using System.Security.Cryptography;

namespace Ribbons.Cryptography
{
    public static class HashExtensions
    {
        private const int SaltSize = 64;
        private const int HashSize = 64;
        private const int Iterations = 10000;

        /// <summary>
        /// Gets the <see cref="MD5"/> hash of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ComputeMD5(this string str)
        {
            return MD5.HashData(str.UTF8Bytes());
        }

        /// <summary>
        /// Gets the <see cref="SHA1"/> hash of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ComputeSHA1(this string str)
        {
            return SHA1.HashData(str.UTF8Bytes());
        }

        /// <summary>
        /// Gets the <see cref="SHA256"/> hash of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ComputeSHA256(this string str)
        {
            return SHA256.HashData(str.UTF8Bytes());
        }

        /// <summary>
        /// Gets the <see cref="SHA512"/> hash of a string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] ComputeSHA512(this string str)
        {
            return SHA512.HashData(str.UTF8Bytes());
        }
    }
}