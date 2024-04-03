using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        public class SectionItem : KeyedItem
        {
            
            [JsonInclude]
            public List<DocumentItem> Contents;

            public SectionItem()
            {
                Contents = new List<DocumentItem>();
            }

            public SectionItem(string source)
            {
                //Need to wrap deserialization into a try catch block
                //If there is an error in reading we should do something
                SectionItem temporary =(
                    JsonSerializer.Deserialize<SectionItem>(source)
                );

                this.Value = temporary.Value;
                this.Type = temporary.Type;
                this.Contents = temporary.Contents;
                this.Key = temporary.Key;
            }

            public override string ToString()
            {
                return JsonSerializer.Serialize(this);
            }
        }
    }

}
