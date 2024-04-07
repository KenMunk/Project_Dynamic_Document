using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDocumentLibraryUnitTests.StructureTests
{
    internal class ExpectedOutputs
    {
        private static string PropertyEntry(string value)
        {
            return (
                ((value != null) ? "\"" : "") +
                (value != null ? value : "null") +
                (value != null ? "\"" : "")
            );
        }

        public static string DocumentItemOutput(string type, string value)
        {
            return ("{" +
                "\"Type\":" + PropertyEntry(type) + "," +
                "\"Value\":" + PropertyEntry(value) +
            "}");
        }

        public static string KeyedItemOutput(string key, string type , string value)
        {
            return ("{" +
                "\"Key\":" + PropertyEntry(key) + "," +
                "\"Type\":" + PropertyEntry(type) + "," +
                "\"Value\":" + PropertyEntry(value) +
            "}");
        }

        public static string SectionItemOutput(
            List<string> content, 
            string key, 
            string type, 
            string value
        )
        {
            string output = "{" + "\"Contents\":[";
            if(content.Count > 0)
            {
                for (int i = 0; i < content.Count; i++)
                {
                    output += content[i];
                    if (i < content.Count - 1) output += ",";
                }
            }
            output += "],";

            output += (
                "\"Key\":" + PropertyEntry(key) + "," +
                "\"Type\":" + PropertyEntry(type) + "," +
                "\"Value\":" + PropertyEntry(value) +
                "}"
            );

            return (output);
        }
    }
}
