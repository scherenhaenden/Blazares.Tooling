using System.Collections.Generic;
using Blazares.Tooling.ObjectByteArrayExtensions;
using NUnit.Framework;

namespace Blazares.Tooling.Test.ObjectByteArrayExtensions
{
    public class ObjetByteArrayConvertionTest
    {
        [Test]
        public void SerializeToByteArray()
        {
            var numbers = new List<int>();
            numbers.Add(2);
            numbers.Add(3);
            numbers.Add(5);
            numbers.Add(7);
            var serialized = numbers.SerializeToByteArray();
            var resultObject= serialized.DeserializeFromByteArray<List<int>>();
            Assert.AreEqual(numbers, resultObject);
        }
    }
}