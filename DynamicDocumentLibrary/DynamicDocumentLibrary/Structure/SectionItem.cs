using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        /// <summary>
        /// A group of Document items<br></br>
        /// <br></br>
        /// Properties:<br></br>
        /// Contents - A list of document items held within this section item
        /// <br></br>
        /// Key - An identifier that is also used to store this object
        /// in a group of other section items<br></br>
        /// Type - An identifier used to help label the data used in 
        /// a section item<br></br>
        /// Value - A label used to preface the contents of a section item
        /// </summary>
        public class SectionItem : KeyedItem
        {
            /// <summary>
            /// The contents of this section item<br><br></br></br>
            /// 
            /// Due to the quirks of serialization, contents must be of the
            /// DocumentItem type for now until a solution can be implemented
            /// </summary>
            [JsonInclude]
            public List<DocumentItem> Contents;

            /// <summary>
            /// A blank section item that is initialized with an empty list
            /// </summary>
            public SectionItem()
            {
                Contents = new List<DocumentItem>();
            }

            /// <summary>
            /// Initializes a new section item with just the reference key
            /// and an empty list
            /// </summary>
            /// <param name="Key">A reference value used
            /// to help identify this section item</param>
            public SectionItem(string Key)
            {
                this.Key = Key;
                Contents = new List<DocumentItem>();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Key"></param>
            /// <param name="Type"></param>
            /// <param name="Value"></param>
            public SectionItem(string Key, string Type, string Value)
            {
                this.InitValues(Key, Type, Value);
            }

            /// <summary>
            /// Initializes the values of this object with all parameters.
            /// The primary purpose of this to reduce the overall amount
            /// of coding needed to initialize a new derivative of any
            /// document item template derived object
            /// </summary>
            /// <param name="key"></param>
            /// <param name="type"></param>
            /// <param name="value"></param>
            /// <param name="Contents"></param>
            public void InitValues(
                string key, 
                string type, 
                string value, 
                List<DocumentItem> Contents
            )
            {
                this.InitValues(key, type, value);
                this.Contents = Contents;
            }

            public SectionItem(
                string key, 
                string type, 
                string value, 
                List<DocumentItem> Contents
            )
            {
                this.InitValues(key, type, value, Contents);
            }

            public SectionItem(List<DocumentItem> contents)
            {
                this.Contents = contents;
            }



            /// <summary>
            /// Deserializes a string value into a Keyed Item object
            /// </summary>
            /// <param name="source">The source JSON that is 
            /// ingested to try and populate this object.  If string
            /// is not a valid JSON object no values will be populated
            /// and the state of the object will remain the same</param>
            /// <returns>A true or false state of whether or not
            /// the source was successfully deserialized.  If the deserialization
            /// was successful the method will return true.</returns>
            public override bool Deserialize(string source)
            {
                try
                {
                    SectionItem temporary = (
                    JsonSerializer.Deserialize<SectionItem>(source)
                    );

                    this.Value = temporary.Value;
                    this.Type = temporary.Type;
                    this.Contents = temporary.Contents;
                    this.Key = temporary.GetKey();
                    return true;
                }
                catch
                {
                    return false;
                }
            }

            /// <summary>
            /// The string value of this object.
            /// </summary>
            /// <returns>Returns a JSON representation of this object
            /// </returns>
            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }

}
