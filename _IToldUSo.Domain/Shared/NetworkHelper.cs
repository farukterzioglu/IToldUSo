﻿using System;
using System.Collections.Generic;
using System.Text;
using Neo.Lux.Core;

namespace IToldUSo.Domain.Shared
{
    public enum NetworkType
    {
        Privnet,
        Testnet,
        CozTestnet,
        Mainnet
    }

    public static class NetworkHelper
    {
        /// <summary>
        /// Gets the Neo RPC for the specified network type.  Defaults to Testnet
        /// </summary>
        /// <param name="type">NetworkType - network to use</param>
        /// <returns>NeoRPC - the RPC for the requested network</returns>
        public static NeoRPC GetNeoRPCForType(NetworkType type)
        {
            switch (type)
            {
                case NetworkType.Mainnet:
                    return NeoRPC.ForMainNet();
                case NetworkType.Testnet:
                    return NeoRPC.ForTestNet();
                case NetworkType.CozTestnet:
                    throw new Exception("COZ Testnet not implemented yet");
                case NetworkType.Privnet:
                    return NeoRPC.ForPrivateNet();
            }

            return NeoRPC.ForTestNet();
        }
    }
}
