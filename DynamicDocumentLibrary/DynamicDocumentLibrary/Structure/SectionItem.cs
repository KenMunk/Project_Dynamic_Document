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

            public SectionItem(String Key)
            {
                this.Key = Key;
                Contents = new List<DocumentItem>();
            }

            public SectionItem(String Key, String Type, String Value)
            {
                
            }

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

            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }

}
