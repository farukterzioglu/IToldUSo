using System;

using System.Numerics;
using IToldUSo.Domain.Shared;
using Neo.Lux.Core;
using Neo.Lux.Cryptography;
using Neo.Lux.Utils;

namespace IToldUSo.Domain
{
    public class ContractWrapper
    {
        private static string _contractScriptHash = "a5e8d7e045caccc7574c1edb1cca62d5aba59f26";
        private NeoRPC _api;

        /// <summary>
        /// Facilitates the invoking of the IToldUSo Smart Contract
        /// </summary>
        /// <param name="networkType">Network to use</param>
        public ContractWrapper(NetworkType networkType)
        {
            _api = NetworkHelper.GetNeoRPCForType(networkType);
        }

        public string ReadFromBlockchain(byte[] text)
        {
            byte[] privKey = "1dd37fba80fec4e6a6f13fd708d8dcb3b29def768017052f6c930fa1c5d90bbb".HexToBytes();  // can be any valid private key
            var myKeys = new KeyPair(privKey);

            var response = _api
                    .CallContract(myKeys, _contractScriptHash.HexToBytes(), "readFromBlockchain", new object[] { text });
            response = _api.InvokeScript(_contractScriptHash.HexToBytes(), "readFromBlockchain", new object[] { text });

            return response.transaction.Hash.ToString();
        }

        public byte[] WriteToBlockchain(byte[] text)
        {
            byte[] privKey = "1dd37fba80fec4e6a6f13fd708d8dcb3b29def768017052f6c930fa1c5d90bbb".HexToBytes();  // can be any valid private key
            var myKeys = new KeyPair(privKey);

            var response = _api
                .CallContract(myKeys, _contractScriptHash.HexToBytes(), "writeToBlockchain", new object[] { text });
            response = _api.InvokeScript(_contractScriptHash.HexToBytes(), "writeToBlockchain", new object[] { text });

            return null;
        }
    }
}
