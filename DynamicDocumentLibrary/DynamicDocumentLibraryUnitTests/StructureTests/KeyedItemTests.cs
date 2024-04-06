using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using DynamicDocumentLibrary.Structure;

namespace DynamicDocumentLibraryUnitTests.StructureTests
{

    [TestClass]
    public class KeyedItemTests
    {
        /* template expected values
        
         string expected = "{" +
            "\"Key\":\"TestType\"," +
            "\"Type\":\"TestType\"," +
            "\"Value\":\"SuccessfulValue\"" +
        "}";

         string expected = "{" +
            "\"Key\":null," +
            "\"Type\":null," +
            "\"Value\":null" +
        "}";

         */

        private void CompareExpectedAndReceived(
            string expected,
            KeyedItem received)
        {

            Console.WriteLine("Expected output is: " + expected);

            Console.WriteLine("Actual output is: " + received);

            Assert.AreEqual(expected, received.ToString());
        }

        private void CompareExpectedAndReceived(
            string expected,
            string received)
        {

            Console.WriteLine("Expected output is: " + expected);

            Console.WriteLine("Actual output is: " + received);

            Assert.AreEqual(expected, received);
        }

        [TestMethod]
        public void TestDefaultBlank()
        {
            KeyedItem testItem = new KeyedItem();

            string expected = "{" +
                "\"Key\":null," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            CompareExpectedAndReceived(expected, testItem);
        }

        [TestMethod]
        public void TestKeyInit()
        {
            string testKey = "First Key";

            KeyedItem keyedItem = new KeyedItem(testKey);

            string expected = "{" +
                "\"Key\":\""+testKey+"\"," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            CompareExpectedAndReceived(expected, keyedItem);
        }

        [TestMethod]
        public void TestKeyModification()
        {

            string oldTestKey = "Old Key";
            string testKey = "First Key";

            KeyedItem keyedItem = new KeyedItem(oldTestKey);

            keyedItem.OverwriteKeyWith("First Key");

            string expected = "{" +
                "\"Key\":\"" + testKey + "\"," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            CompareExpectedAndReceived(expected, keyedItem);
        }

        [TestMethod]
        public void TestGetKey()
        {

            string testKey = "First Key";

            KeyedItem keyedItem = new KeyedItem(testKey);

            CompareExpectedAndReceived(testKey, keyedItem.GetKey());
        }

        [TestMethod]
        public void TestWithFullInit()
        {
            string testKey = "TestKey";
            string testType = "AType";
            string testValue = "SomeValue";

            string expected = "{" +
                "\"Key\":\"" + testKey + "\"," +
                "\"Type\":\"" + testType + "\"," +
                "\"Value\":\"" + testValue + "\"" +
            "}";

            KeyedItem received = new KeyedItem(testKey, testType, testValue);

            CompareExpectedAndReceived(expected, received);
        }

    }
}
