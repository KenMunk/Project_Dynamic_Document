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
