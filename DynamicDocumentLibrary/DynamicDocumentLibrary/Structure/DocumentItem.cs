﻿using System;
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
            /// <br></br>
            /// <p>
            /// A potential issue with this and other string based properties
            /// is that they can be interchangable which makes enforcing
            /// implementation safely will be difficult without specific typing
            /// </p>
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
            /// <p>
            /// A potential issue with this and other string based properties
            /// is that they can be interchangable which makes enforcing
            /// implementation safely will be difficult without specific typing
            /// </p>
            /// </summary>
            public string Value { get; set; }

            /// <summary>
            /// Initializes a blank document item
            /// <br><br></br></br>
            /// 
            /// Type and Value will initialize as null
            /// </summary>
            public DocumentItem() { }

            /// <summary>
            /// Fully initializes a document item instance
            /// </summary>
            /// <param name="Type">The label describing
            /// the type that this document item represents in
            /// a document.  The goal is to enable users to define
            /// components within a document without needing
            /// to programatically define the document components</param>
            /// <br></br>
            /// <param name="Value">The payload of a document item
            /// this can be any string content within a document.  Default
            /// utilization will only present the Value within a document
            /// </param>
            public DocumentItem(string Type, string Value)
            {
                this.Type = Type;
                this.Value = Value;
            }

            /// <summary>
            /// Initializes the values within Document item derived
            /// instances
            /// </summary>
            /// <param name="Type">The label describing
            /// the type that this document item represents in
            /// a document.  The goal is to enable users to define
            /// components within a document without needing
            /// to programatically define the document components</param>
            /// <br></br>
            /// <param name="Value">The payload of a document item
            /// this can be any string content within a document.  Default
            /// utilization will only present the Value within a document
            /// <seealso cref="Value"/>See Value Parameter</seealso>
            /// </param>
            public void InitValues(string type, string value)
            {
                this.Type = type;
                this.Value= value;
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