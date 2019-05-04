using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopSmartTool.DAL.Repositories;

namespace ShopSmartTool.UnitTests
{
    [TestClass]
    public class ShopSmartToolUnitTests
    {
        ItemsRepository _itemRepository;

        public ShopSmartToolUnitTests()
        {
            _itemRepository = new ItemsRepository();
        }

        [TestMethod]
        public void TestMethodForNoProduct()
        {
            Assert.AreEqual(0, _itemRepository.CalculateTotalAmount(string.Empty));
        }

        [TestMethod]
        public void TestMethodForSingleProduct()
        {
            Assert.AreEqual(50, _itemRepository.CalculateTotalAmount("A"));
        }

        [TestMethod]
        public void TestMethodForTwoProducts()
        {
            Assert.AreEqual(80, _itemRepository.CalculateTotalAmount("AB"));
        }

        [TestMethod]
        public void TestMethodForFourProducts()
        {
            Assert.AreEqual(115, _itemRepository.CalculateTotalAmount("CDBA"));
        }

        [TestMethod]
        public void TestMethodForTwoSimilarProducts()
        {
            Assert.AreEqual(100, _itemRepository.CalculateTotalAmount("AA"));
        }

        [TestMethod]
        public void TestMethodForThreeSimilarProducts()
        {
            Assert.AreEqual(130, _itemRepository.CalculateTotalAmount("AAA"));
        }

        [TestMethod]
        public void TestMethodForFiveProducts()
        {
            Assert.AreEqual(175, _itemRepository.CalculateTotalAmount("AAABB"));
        }
    }
}
