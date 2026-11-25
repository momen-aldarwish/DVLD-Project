using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DVLD_BusinessLogicLayer
{
    internal class clsUtil
    {
        public static string HashCompute (string Input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedInput =  sha256.ComputeHash(Encoding.UTF8.GetBytes(Input));

                return BitConverter.ToString(hashedInput).Replace("-", "").ToLower();
            }
        }
    }
}
