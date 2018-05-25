using System;
using IToldUSo.Domain;
using IToldUSo.Domain.Shared;

namespace IToldUSo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var contract = new ContractWrapper(NetworkType.Privnet);
            var hash = contract.WriteToBlockchain("test text".AsByteArray());
            var readValue = contract.ReadFromBlockchain(hash);

            if ("test text" != readValue) throw new NotSupportedException();
        }
    }
}
