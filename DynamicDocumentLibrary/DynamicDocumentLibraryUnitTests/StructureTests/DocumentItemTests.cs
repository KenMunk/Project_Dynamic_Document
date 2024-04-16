using DynamicDocumentLibrary.Structure;

namespace DynamicDocumentLibraryUnitTests.StructureTests
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
            string expected = ExpectedOutputs.DocumentItemOutput(
                null,
                null
            );
            Console.WriteLine("Blank test Document Item is {0}", result);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CanInitWithTypeAndValue()
        {
            string testType = "TestType";
            string testValue = "SuccessfulValue";

            DocumentItem testItem = new DocumentItem(
                testType,
                testValue
            );

            string result = testItem.ToString();
            Console.WriteLine("Fully initialized test Item is: {0}", result);

            string expected = ExpectedOutputs.DocumentItemOutput(
                testType,
                testValue
            );

            Console.WriteLine("Expected value is: {0}", expected);

            Assert.AreEqual(expected, result);
        }
    }
}