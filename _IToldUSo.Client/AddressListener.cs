using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Neo.Lux.Core;
using Neo.Lux.Utils;

namespace IToldUSo.Client
{
    class Listener
    {
        void Main(string[] args)
        {
            string address;

            do
            {
                Console.WriteLine("Write an NEO address to listen:");
                address = Console.ReadLine();
            } while (!address.IsValidAddress());

            var api = NeoRPC.ForTestNet();

            var oldBlockCount = api.GetBlockHeight();

            var targetScriptHash = address.AddressToScriptHash();

            Console.WriteLine("Now listening for transactions...");

            do
            {
                // wait for block generation
                Thread.Sleep(10000);

                var newBlockCount = api.GetBlockHeight();

                if (newBlockCount != oldBlockCount)
                {
                    Console.WriteLine($"Fetching block {newBlockCount}");

                    // retrieve latest block
                    var block = api.GetBlock(newBlockCount);

                    if (block == null)
                    {
                        Console.WriteLine($"Failed...");
                        continue;
                    }

                    oldBlockCount = newBlockCount;

                    // inspect each tx in the block for inputs sent to the target address
                    foreach (var tx in block.transactions)
                    {
                        var amounts = new Dictionary<string, decimal>();

                        foreach (var output in tx.outputs)
                        {
                            if (true)//output.scriptHash.SequenceEqual(targetScriptHash))
                            {
                                var asset = NeoAPI.SymbolFromAssetID(output.assetID);

                                if (amounts.ContainsKey(asset))
                                {
                                    amounts[asset] += output.value;
                                }
                                else
                                {
                                    amounts[asset] = output.value;
                                }

                            }
                        }

                        if (amounts.Count > 0)
                        {
                            foreach (var entry in amounts)
                            {
                                Console.WriteLine($"{entry.Value} {entry.Key} was sent to {address}, in tx {tx.Hash}");
                            }
                        }
                    }
                }

            } while (true);
        }
    }
}
