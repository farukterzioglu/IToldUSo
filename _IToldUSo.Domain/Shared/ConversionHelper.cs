using System;
using System.Collections.Generic;
using System.Text;
using Neo.Lux.Utils;

namespace IToldUSo.Domain.Shared
{

    public static class ConversionHelper
    {
        /// <summary>
        /// Byteses to hexadecimal.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Hex string resulting from the conversion</returns>
        public static string BytesToHex(byte[] bytes)
        {
            return bytes.ToHexString();
        }

        /// <summary>
        /// Hexadecimals to bytes.
        /// </summary>
        /// <param name="hexString">The hexadecimal string.</param>
        /// <returns>byte[] representing the string.</returns>
        public static byte[] HexToBytes(string hexString)
        {
            return hexString.HexToBytes();
        }

        /// <summary>
        /// Strings to bytes.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The byte representation of the string</returns>
        public static byte[] StringToBytes(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        /// <summary>
        /// Byteses to string.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>The string representation of the bytes</returns>
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.ASCII.GetString(bytes);
        }

        public static string AsString(this byte[] bytes)
        {
            return BytesToString(bytes);
        }

        public static byte[] AsByteArray(this string text)
        {
            return StringToBytes(text);
        }
    }
}
