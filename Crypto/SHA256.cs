using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HApi.Crypto
{
    [Serializable]
    public class SHA256Hash : IEquatable<SHA256Hash>
    {
        private readonly byte[] Output;
        public SHA256Hash(string rawData)
        {
            using SHA256 sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            Output = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
        }

        public bool Equals([AllowNull] SHA256Hash other)
        {
            if (other == null)
                return false;

            if (other.Output.Length != Output.Length)
                return false;

            for(int i = 0; i < Output.Length; i++)
            {
                if (other.Output[i] != Output[i])
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Output.Length; i++)
            {
                builder.Append(Output[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
