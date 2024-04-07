﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        /// <summary>
        /// A group of Section Items<br></br>
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
        public class SectionGroup : KeyedItem
        {
            /// <summary>
            /// The contents of this section item<br><br></br></br>
            /// 
            /// Due to the quirks of serialization, contents must be of the
            /// SectionItem type for now until a solution can be implemented
            /// </summary>
            [JsonInclude]
            public List<SectionItem> Contents;

            /// <summary>
            /// A blank section item that is initialized with an empty list
            /// </summary>
            public SectionGroup()
            {
                Contents = new List<SectionItem>();
            }

            public SectionGroup(string Key)
            {
                this.Key = Key;
                Contents = new List<SectionItem>();
            }

            public SectionGroup(string Key, string Type, string Value)
            {
                this.InitValues(Key, Type, Value);
            }

            public void InitValues(
                string key, 
                string type, 
                string value, 
                List<SectionItem> Contents
            )
            {
                this.InitValues(key, type, value);
                this.Contents = Contents;
            }

            public SectionGroup(
                string key, 
                string type, 
                string value, 
                List<SectionItem> Contents
            )
            {
                this.InitValues(key, type, value, Contents);
            }

            public SectionGroup(List<SectionItem> contents)
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
                    SectionGroup temporary = (
                    JsonSerializer.Deserialize<SectionGroup>(source)
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