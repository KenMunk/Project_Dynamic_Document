using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {

        [JsonDerivedType(typeof(KeyedItem), typeDiscriminator: "keyeditem")]
        [JsonDerivedType(typeof(SectionItem), typeDiscriminator: "sectionitem")]
        public class KeyedItem : DocumentItem
        {
            /// <summary>
            /// 
            /// Holds he Key reference of a document section.
            /// <br></br><br></br>
            /// The Key can only be modified when null or empty to
            /// maintain data integrity.  The reason for this
            /// is that if a reference is already set for a
            /// document item, any changes to it will cause
            /// a cascade of reference errors.  This will also mean
            /// that there needs to be external validation of
            /// the Keys to ensure that there are no duplicate Keys
            /// being used for different items.
            /// 
            /// <br></br>
            /// <br></br>
            /// 
            /// <b>
            /// There are two operations available for Key, get and set
            /// </b>
            /// 
            /// <br>Get: returns the current value of Key</br>
            /// 
            /// <br>
            /// Set: sets the value of the Key if the Key is null or empty
            /// if the Key value is not empty the value will not be changed
            /// </br>
            /// 
            /// <br>
            /// <b>
            /// If there are duplicate values, the 
            /// implementation is wrong
            /// </b>
            /// </br>
            /// 
            /// References Key for storage and retrieval
            /// 
            /// <p>
            /// A potential issue with this and other string based properties
            /// is that they can be interchangable which makes enforcing
            /// implementation safely will be difficult without specific typing
            /// </p>
            /// </summary>
            [JsonInclude]
            protected string Key { get; set; }

            /// <summary>
            /// Initializes and empty KeyedItem Object
            /// </summary>
            public KeyedItem()
            {
            }

            /// <summary>
            /// Initializes this object with just the Key value initialized
            /// </summary>
            /// <param name="key">A reference identifier for this object
            /// to be used to find this object for later use</param>
            public KeyedItem(string key){
                this.Key = key;
            }

            /// <summary>
            /// A full initialization of a keyed item object with a reference
            /// identifier, type identifier, and value payload
            /// </summary>
            /// <param name="key">A reference identifier for this object
            /// to be used to find this object for later use</param>
            /// <param name="type">A type identifier for filtering purposes
            /// </param>
            /// <param name="value">A description value used to help
            /// explain the contents to the reader of this document</param>
            public KeyedItem(string key, string type, string value)
            {
                this.InitValues(key, type, value);
            }

            /// <summary>
            /// Initializes the values within Document item derived
            /// instances
            /// </summary>
            /// <param name="key">The payload of a document item
            /// this can be any string content within a document.  Default
            /// utilization will only present the Value within a document
            /// <seealso cref="Key"/>See Parameter</seealso>
            /// </param>
            /// <param name="type">The label describing
            /// the type that this document item represents in
            /// a document.  The goal is to enable users to define
            /// components within a document without needing
            /// to programatically define the document components</param>
            /// <br></br>
            /// <param name="value">The payload of a document item
            /// this can be any string content within a document.  Default
            /// utilization will only present the Value within a document
            /// <seealso cref="Value"/>See Value Parameter</seealso>
            /// </param>
            public void InitValues(string key, string type, string value)
            {
                this.Key= key;
                this.InitValues(type, value);
            }

            /// <summary>
            /// Overwrites the existing Key with a new value.
            /// <br><br></br></br>
            /// <b>USE WITH CAUTION, WILL CAUSE CASCADING ERRORS</b>
            /// <br><br></br></br>
            /// In the rare instance that a key value needs to be
            /// overwritten for some reason, this method will force
            /// the value of the Key to become the new key.  This
            /// comes at the risk of complete document destruction.
            /// </summary>
            /// <param name="newKey"></param>
            public void OverwriteKeyWith(string newKey)
            {
                this.Key = newKey;
            }

            /// <summary>
            /// In order to protect the real value of the key the key value of
            /// objects derived from this class can only be accessed via this
            /// method to promote better protections of the reference data.
            /// </summary>
            /// <returns>The Key value of this object</returns>
            public string GetKey()
            {
                return this.Key+"";
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
                    KeyedItem temporary = (
                    JsonSerializer.Deserialize<KeyedItem>(source)
                    );

                    this.Value = temporary.Value;
                    this.Type = temporary.Type;
                    if(temporary.GetKey() != "")
                    {
                        this.Key = temporary.GetKey();
                    }
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
                return JsonSerializer.Serialize<KeyedItem>(this);
            }
        }
    }

}
