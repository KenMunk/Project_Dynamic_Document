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

        /// <summary>
        /// Compares expected and received input values within an 
        /// assertion and outputs the current outputs into console for
        /// ease of troubleshooting
        /// </summary>
        /// <param name="expected">The expected string output value
        /// </param>
        /// <param name="received">An object to be converted to string
        /// to verify that matches the expected output</param>
        private void CompareExpectedAndReceived(
            string expected,
            KeyedItem received)
        {

            Console.WriteLine("Expected output is: " + expected);

            Console.WriteLine("Actual output is: " + received);

            Assert.AreEqual(expected, received.ToString());
        }

        /// <summary>
        /// Compares expected and received input values within an 
        /// assertion and outputs the current outputs into console for
        /// ease of troubleshooting
        /// </summary>
        /// <param name="expected">The expected string output value
        /// </param>
        /// <param name="received">An object to be converted to string
        /// to verify that matches the expected output</param>
        private void CompareExpectedAndReceived(
            string expected,
            string received)
        {

            Console.WriteLine("Expected output is: " + expected);

            Console.WriteLine("Actual output is: " + received);

            Assert.AreEqual(expected, received);
        }

        /// <summary>
        /// Tests a blank Keyed item to verify the structure, and validate that
        /// all values are null
        /// </summary>
        [TestMethod]
        public void TestDefaultBlank()
        {
            KeyedItem testItem = new KeyedItem();

            string expected = ExpectedOutputs.KeyedItemOutput(
                null,
                null,
                null
            );

            CompareExpectedAndReceived(expected, testItem);
        }

        [TestMethod]
        public void TestKeyInit()
        {
            string testKey = "First Key";

            KeyedItem keyedItem = new KeyedItem(testKey);

            string expected = ExpectedOutputs.KeyedItemOutput(
                testKey,
                null,
                null
            );

            CompareExpectedAndReceived(expected, keyedItem);
        }

        [TestMethod]
        public void TestKeyModification()
        {

            string oldTestKey = "Old Key";
            string testKey = "First Key";

            KeyedItem keyedItem = new KeyedItem(oldTestKey);

            keyedItem.OverwriteKeyWith(testKey);

            string expected = ExpectedOutputs.KeyedItemOutput(
                testKey,
                null,
                null
            );

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

            string expected = ExpectedOutputs.KeyedItemOutput(
                testKey,
                testType,
                testValue
            );

            KeyedItem received = new KeyedItem(testKey, testType, testValue);

            CompareExpectedAndReceived(expected, received);
        }

    }
}
