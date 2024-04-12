using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicDocumentLibraryUnitTests.StructureTests
{
    /// <summary>
    /// An internal class with static methods that can be used to construct
    /// expected output values without having to manually build the 
    /// structures which has the potential to be highly complex
    /// </summary>
    internal class ExpectedOutputs
    {
        /// <summary>
        /// A granular method for building out object properties in JSON
        /// format in a way that the System.text.JSON can understand when
        /// deserializing and in a way that matches the expected outputs of
        /// System.text.JSON outputs
        /// </summary>
        /// <param name="value">The value payload of a JSON property
        /// </param>
        /// <returns>The expected property value of a JSON object
        /// </returns>
        private static string PropertyEntry(string value)
        {
            return (
                ((value != null) ? "\"" : "") +
                (value != null ? value : "null") +
                (value != null ? "\"" : "")
            );
        }

        /// <summary>
        /// Builds and returns the expected ouput of a DocumentItem class
        /// when rendered to JSON string format.
        /// </summary>
        /// <param name="type">The type identifier payload of
        /// an object</param>
        /// <param name="value">The expected value payload of an
        /// object</param>
        /// <returns>The expected output of a DocumentItem class when
        /// rendered to JSON string format</returns>
        public static string DocumentItemOutput(string type, string value)
        {
            return ("{" +
                "\"Type\":" + PropertyEntry(type) + "," +
                "\"Value\":" + PropertyEntry(value) +
            "}");
        }

        /// <summary>
        /// Builds and returns the expected ouput of a KeyedItem class
        /// when rendered to JSON string format.
        /// </summary>
        /// <param name="key">The item reference payload of an object
        /// </param>
        /// <param name="type">The type identifier payload of
        /// an object</param>
        /// <param name="value">The expected value payload of an
        /// object</param>
        /// <returns>The expected output of a KeyedItem class when
        /// rendered to JSON string format</returns>
        public static string KeyedItemOutput(string key, string type , string value)
        {
            return ("{" +
                "\"Key\":" + PropertyEntry(key) + "," +
                "\"Type\":" + PropertyEntry(type) + "," +
                "\"Value\":" + PropertyEntry(value) +
            "}");
        }

        /// <summary>
        /// Builds and returns the expected ouput of a SectionItem class
        /// when rendered to JSON string format.
        /// </summary>
        /// <param name="content">The expected content payload of
        /// this object </param>
        /// <param name="key">The item reference payload of an object
        /// </param>
        /// <param name="type">The type identifier payload of
        /// an object</param>
        /// <param name="value">The expected value payload of an
        /// object</param>
        /// <returns>The expected output of a SectionItem class when
        /// rendered to JSON string format</returns>
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
