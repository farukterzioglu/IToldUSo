using System;
using IToldUSo.Domain;
using IToldUSo.Domain.Shared;
using Neo.Lux.Utils;
using NUnit.Framework;

namespace IToldUSo.Tests
{
    [TestFixture]
    public class ContractWrapperTests
    {
        [Test]
        public void Invoke()
        {
            var contract = new ContractWrapper(NetworkType.Privnet);
            var hash = contract.WriteToBlockchain("test text".ToBytes());
            contract.ReadFromBlockchain(hash);

            Assert.AreEqual("test text", hash);
        }
    }
}
