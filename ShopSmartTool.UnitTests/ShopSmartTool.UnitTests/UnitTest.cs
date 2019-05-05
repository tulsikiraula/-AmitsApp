using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopSmartTool.DAL.Repositories;

namespace ShopSmartTool.UnitTests
{
    /// <summary>
    /// Unit test cases for the Go Shopping application
    /// </summary>
    [TestClass]
    public class UnitTest
    {

        ItemsRepository _itemRepository;
        /// <summary>
        /// Initiazation
        /// </summary>
        public UnitTest()
        {
            _itemRepository = new ItemsRepository();
        }

        [TestMethod]
        public void TestCaseNoItemSelected()
        {
            Assert.AreEqual(0, _itemRepository.CalculateTotalAmount(""));
        }

        [TestMethod]
        public void TestCaseSingleItemSelected()
        {
            Assert.AreEqual(50, _itemRepository.CalculateTotalAmount("A"));
        }

        [TestMethod]
        public void TestCaseTwoItemsSelected()
        {
            Assert.AreEqual(80, _itemRepository.CalculateTotalAmount("AB"));
        }

        [TestMethod]
        public void TestCaseFourItemsSelected()
        {
            Assert.AreEqual(115, _itemRepository.CalculateTotalAmount("CDBA"));
        }

        [TestMethod]
        public void TestCaseTwoSameItemsSelected()
        {
            Assert.AreEqual(100, _itemRepository.CalculateTotalAmount("AA"));
        }

        [TestMethod]
        public void TestCaseThreeSameItemsSelected()
        {
            Assert.AreEqual(130, _itemRepository.CalculateTotalAmount("AAA"));
        }

        [TestMethod]
        public void TestCaseFiveItemsSelected()
        {
            Assert.AreEqual(175, _itemRepository.CalculateTotalAmount("AAABB"));
        }
    }
}

