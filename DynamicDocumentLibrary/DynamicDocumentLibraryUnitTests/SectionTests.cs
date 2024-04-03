using System;
using System.Collections.Generic;
using DynamicDocumentLibrary.Structure;


namespace DynamicDocumentLibraryUnitTests
{

    [TestClass]
    public class SectionTests
    {

        [TestMethod]
        public void TestBlankSection()
        {
            //Create a new section
            SectionItem testSection = new SectionItem();
            string result = testSection.ToString();
            Console.WriteLine("Blank Test Section is {0}", result);

            string expected = "{" +
                "\"Contents\":[]," +
                "\"Key\":null," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void AddTwoDocumentItems()
        {
            SectionItem sectionItem = new SectionItem();

            sectionItem.Contents.Add(
                new DocumentItem(
                    "FirstTest",
                    "you see"
                )
            );
            sectionItem.Contents.Add(
                new DocumentItem(
                    "SecondTest",
                    "how about now"
                )
            );

            Console.WriteLine(
                "Section item with two doc items: " +
                sectionItem
            );

            string expected = "{" +
                "\"Contents\":[" +
                    "{" +
                        "\"Type\":\"FirstTest\"," +
                        "\"Value\":\"you see\"" +
                    "}," +
                    "{" +
                        "\"Type\":\"SecondTest\"," +
                        "\"Value\":\"how about now\"" +
                    "}" +
                "]," +
                "\"Key\":null," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            Assert.AreEqual(expected, sectionItem.ToString());

        }

        [TestMethod]
        public void RecoverDataWithTwoObjects()
        {
            string expected = "{" +
                "\"Contents\":[" +
                    "{" +
                        "\"Type\":\"FirstTest\"," +
                        "\"Value\":\"you see\"" +
                    "}," +
                    "{" +
                        "\"Type\":\"SecondTest\"," +
                        "\"Value\":\"how about now\"" +
                    "}" +
                "]," +
                "\"Key\":null," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            SectionItem sectionItem = new SectionItem(expected);

            Assert.AreEqual(expected, sectionItem.ToString());
        }
    }
}
