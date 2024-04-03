using DynamicDocumentLibrary.Structure;

namespace DynamicDocumentLibraryUnitTests
{
    [TestClass]
    public class DocumentItemTests
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TypeAndValueBlankOnDefault()
        {
            DocumentItem testDocumentItem = new DocumentItem();

            string result = testDocumentItem.ToString();
            string expected = "{\"Type\":null,\"Value\":null}";
            Console.WriteLine("Blank test Document Item is {0}", result);

            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void CanInitWithTypeAndValue()
        {
            DocumentItem testItem = new DocumentItem(
                "TestType",
                "SuccessfulValue"
            );

            string result = testItem.ToString();
            Console.WriteLine("Fully initialized test Item is: {0}", result);

            string expected = "{\"Type\":\"TestType\",\"Value\":\"SuccessfulValue\"}";
            Console.WriteLine("Expected value is: {0}", expected);

            Assert.AreEqual(expected, result);
        }
    }
}