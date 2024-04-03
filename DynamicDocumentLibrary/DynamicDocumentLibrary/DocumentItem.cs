using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        public class DocumentItem : DocumentItemTemplate
        {
            /// <summary>
            /// Defines the type of item that this document item is.
            /// <br></br>
            /// <br></br>
            /// DocumentItem types are labels used to better organize
            /// a dynamic document so that specific element types can
            /// be selected to be included or ommitted from an exported
            /// dynamic document
            /// <br></br>
            /// <br></br>
            /// Example:
            /// <br></br>
            /// Type = "Phone Number"
            /// <br></br>
            /// Value = "+1(222)333-4444"
            /// </summary>
            public string Type { get; set; }

            /// <summary>
            /// Defines the value of a document item.
            /// <br></br><br></br>
            /// DocumentItem values can be any payload string value
            /// there is no binding requirement to how the value is
            /// structured so long as it is a string.
            /// <br></br><br></br>
            /// Example:
            /// <br></br>
            /// Type = "Phone Number"
            /// <br></br>
            /// Value = "+1(222)333-4444"
            /// </summary>
            public string Value { get; set; }

            public DocumentItem() { }

            public DocumentItem(string source)
            {

            }

            public DocumentItem(string Type, string Value)
            {
                this.Type = Type;
                this.Value = Value;
            }

            public override bool Deserialize(string source)
            {
                try
                {
                    DocumentItem temporaryItem = (
                        JsonSerializer.Deserialize<DocumentItem>(source)
                    );

                    this.Value = temporaryItem.Value;
                    this.Type = temporaryItem.Type;
                }
                catch
                {
                    return false;
                }
                return true;
            }

            public override string ToString() => JsonSerializer.Serialize(this);



        }

    }
}
