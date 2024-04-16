using System;
using System.Collections.Generic;
using DynamicDocumentLibrary.Structure;


namespace DynamicDocumentLibraryUnitTests.StructureTests
{

    [TestClass]
    public class SectionTests
    {

        /// <summary>
        /// Creates and compares a blank section item against its expected
        /// output value when converted to a JSON string value.
        /// </summary>
        [TestMethod]
        public void TestBlankSection()
        {
            //Create a new section
            SectionItem testSection = new SectionItem();
            string result = testSection.ToString();
            Console.WriteLine("Blank Test Section is {0}", result);

            List<string> emptyContent = new List<string>();

            string expected = ExpectedOutputs.SectionItemOutput(
                emptyContent,
                null,
                null,
                null
            );

            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Creates a section item object with two document items with
        /// known value outputs and inserts them into a section item class
        /// then compares the expected value against the actual value when
        /// the section item object is converted to a JSON string value
        /// </summary>
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

            List<string> testContents = new List<string>();
            testContents.Add(ExpectedOutputs.DocumentItemOutput(
                "FirstTest",
                "you see"
            ));

            testContents.Add(ExpectedOutputs.DocumentItemOutput(
                "SecondTest",
                "how about now"
            ));

            string expected = ExpectedOutputs.SectionItemOutput(
                testContents,
                null,
                null,
                null
            );

            Assert.AreEqual(expected, sectionItem.ToString());

        }

        /// <summary>
        /// Creates a section item with two additional section iten items
        /// nested within the parent section item and compares it against
        /// its expected value
        /// <br><br></br></br>
        /// The intent of this is to test whether or not a nested structure of
        /// section items can be used to build more complex documents
        /// without the use of additional structure classes  in complex nesting
        /// nesting scenarios
        /// </summary>
        [TestMethod]
        public void AddSubsectionsWithItems()
        {
            SectionItem sectionItem = new SectionItem();

            string[] testTypes = [
                "Sub1.1",
                "Sub1.2",
                "Sub1.3.1",
                "Sub1.3.2"
            ];

            string[] testValues = [
                "See1.1",
                "See1.2",
                "See1.3.1",
                "See1.3.2"
            ];

            sectionItem.Contents.Add(
                new DocumentItem(
                    testTypes[0],
                    testValues[0]
                )
            );
            sectionItem.Contents.Add(
                new DocumentItem(
                    testTypes[1],
                    testValues[1]
                )
            );

            SectionItem subsection1 = new SectionItem();

            subsection1.Contents.Add(
                new DocumentItem(
                    testTypes[2],
                    testValues[2]
                )
            );
            subsection1.Contents.Add(
                new DocumentItem(
                    testTypes[3],
                    testValues[3]
                )
            );

            sectionItem.Contents.Add(subsection1);

            Console.WriteLine(
                "Section item with two doc items: " +
                sectionItem
            );

            List<string> testPayload = new List<string>();
            List<string> testSection2Payload = new List<string>();

            testPayload.Add(ExpectedOutputs.DocumentItemOutput(
                testTypes[0],
                testValues[0]
            ));

            testPayload.Add(ExpectedOutputs.DocumentItemOutput(
                testTypes[1],
                testValues[1]
            ));

            testSection2Payload.Add(ExpectedOutputs.DocumentItemOutput(
                testTypes[2],
                testValues[2]
            ));

            testSection2Payload.Add(ExpectedOutputs.DocumentItemOutput(
                testTypes[3],
                testValues[3]
            ));


            testPayload.Add(ExpectedOutputs.SectionItemOutput(
                testSection2Payload,
                null,
                null,
                null
            ));

            string expected = ExpectedOutputs.SectionItemOutput(
                testPayload,
                null,
                null,
                null
            );

            /*
            string expected = "{" +
                "\"Contents\":[" +
                    "{" +
                        "\"Type\":\""+testTypes[0]+"\"," +
                        "\"Value\":\"" + testValues[0] + "\"" +
                    "}," +
                    "{" +
                        "\"Type\":\""+testTypes[1]+"\"," +
                        "\"Value\":\"" + testValues[1] + "\"" +
                    "}," +
                    "{" +
                        "\"Contents\":[" +
                            "{" +
                                "\"Type\":\""+testTypes[2]+"\"," +
                                "\"Value\":\"" + testValues[2] + "\"" +
                            "}," +
                            "{" +
                                "\"Type\":\""+testTypes[3]+"\"," +
                                "\"Value\":\"" + testValues[3] + "\"" +
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
            //*//*
                 * If the above content is no longer commented out
                 * then we are going to have issues with comparing the
                 * expected and received outputs of the document components
                 * due to the inclusion of typeDescriptors to promote
                 * polymorphism
            //*///

            Assert.AreEqual(expected, sectionItem.ToString());
        }

        /// <summary>
        /// Attempt to deserialize a JSON string representation of a
        /// section item with two document items nested inside of it and
        /// confirm that serializing the result will result in a matching string
        /// output as the string input.
        /// </summary>
        [TestMethod]
        public void RecoverDataWithTwoSimpleObjects()
        {

            List<string> testContents = new List<string>();
            testContents.Add(ExpectedOutputs.DocumentItemOutput(
                "FirstTest",
                "you see"
            ));

            testContents.Add(ExpectedOutputs.DocumentItemOutput(
                "SecondTest",
                "how about now"
            ));

            string expected = ExpectedOutputs.SectionItemOutput(
                testContents,
                null,
                null,
                null
            );
            /*
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
            "}";//*///

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
