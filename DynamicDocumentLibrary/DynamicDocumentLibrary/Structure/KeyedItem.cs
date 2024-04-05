using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
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
            /// </summary>
            [JsonInclude]
            protected string Key { get; set; }

            public KeyedItem()
            {
            }

            public KeyedItem(string key){
                this.Key = key;
            }

            public KeyedItem(string key, string value, string type)
            {
                this.Key = key;
                this.Value = value;
                this.Type = type;
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

            public string GetKey()
            {
                return this.Key;
            }

            public override bool Deserialize(string source)
            {
                try
                {
                    KeyedItem temporary = (
                    JsonSerializer.Deserialize<KeyedItem>(source)
                    );

                    this.Value = temporary.Value;
                    this.Type = temporary.Type;
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
