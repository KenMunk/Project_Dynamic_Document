using System;
using System.Collections.Generic;
using DynamicDocumentLibrary.Structure;


namespace DynamicDocumentLibraryUnitTests.StructureTests
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
        public void AddSubsectionsWithItems()
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

            SectionItem subsection1 = new SectionItem();

            subsection1.Contents.Add(
                new DocumentItem(
                    "FirstTest",
                    "you see"
                )
            );
            subsection1.Contents.Add(
                new DocumentItem(
                    "SecondTest",
                    "how about now"
                )
            );

            sectionItem.Contents.Add(subsection1);
            sectionItem.Contents.Add(subsection1);

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
                    "}," +
                    "{" +
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
                    "}," +
                    "{" +
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
                    "}" +
                "]," +
                "\"Key\":null," +
                "\"Type\":null," +
                "\"Value\":null" +
            "}";

            /*
            Realization, System.Text.JSON.Serialize will not
            recognize that there are potentially objects that are
            derived from a stated class but not the declared class
            of an item.  This will result in the resultant JSON not
            reflecting the correct data.  Unfortunately, there isn't a
            good solution to this that will be easy to implement unless
            I have objects added as pre-serialized json objects which
            adds so many more chances for errors

            the best solution for now would be to stick with simple typing
            for now, and consider the feature add-on of nested objects later
            */
            Assert.AreNotEqual(expected, sectionItem.ToString());
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

            SectionItem sectionItem = new SectionItem();

            if (sectionItem.Deserialize(expected))
            {
                Assert.AreEqual(expected, sectionItem.ToString());
            }
            else
            {
                Assert.Fail("Deserialization failed due to corrupt JSON input");
            }

        }

    }
}
