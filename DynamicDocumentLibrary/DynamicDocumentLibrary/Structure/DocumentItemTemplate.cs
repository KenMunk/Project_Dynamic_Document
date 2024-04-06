﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        /// <summary>
        /// An interface for all document item objects
        /// </summary>
        public abstract class DocumentItemTemplate
        {
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
            public abstract bool Deserialize(string source);

            /// <summary>
            /// The string value of this object.
            /// </summary>
            /// <returns>Returns a JSON representation of this object
            /// </returns>
            public abstract override string ToString();
        }

    }
}
