using System;
using System.Collections.Generic;
using System.Text.Json;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        public class SectionItem
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
            /// </summary>
            public string Key
            {
                get { return Key; }
                set
                {
                    if (
                        this.Key == null
                        ||
                        this.Key == string.Empty
                    )
                    {
                        this.Key = Key;
                    }
                }
            }

            public List<DocumentItem> contents { get; set; }

            public SectionItem()
            {
            }

            public string toString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }

}
