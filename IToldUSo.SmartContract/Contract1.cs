using System;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using Neo.SmartContract.Framework.Services.System;

namespace IToldUSo.SmartContract
{
    public class Contract1 : Neo.SmartContract.Framework.SmartContract
    {
        public static object Main(string method, object[] args)
        {
            if (method == "writeToBlockchain") return writeToBlockchain((byte[])args[0]);
            if (method == "readFromBlockchain") return readFromBlockchain((byte[])args[0]);

            return false;
        }

        public static string readFromBlockchain(byte[] text)
        {
            if (text.Length == 0) return "0";
            
            return Storage.Get(Storage.CurrentContext, text).AsString();
        }

        public static byte[] writeToBlockchain(byte[] text)
        {
            if (text.Length == 0) return "".AsByteArray();

            var hash = GetTransactionId();
            Storage.Put(Storage.CurrentContext, hash, text);

            return hash;
        }

        #region Private methods 

        private static byte[] GetTransactionId()
        {
            Transaction tx = (Transaction)ExecutionEngine.ScriptContainer;
            return tx.Hash;
        }

        #endregion
    }
}
