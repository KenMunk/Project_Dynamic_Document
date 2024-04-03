using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("Blank Test Section will is {0}", testSection.toString());
        }
    }
}
