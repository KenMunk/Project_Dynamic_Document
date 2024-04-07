using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace DynamicDocumentLibrary.Structure
{
    public class ContentItem
    {
        private Type ContentType { get; set; }

        private string ContentValue { get; set; }


        public ContentItem()
        {
        }

        public void StoreValue(DocumentItem docItem, Type type)
        {
            this.ContentType = type;
            this.ContentValue = docItem.ToString();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        public DocumentItem GetValue()
        {
            if(this.ContentType == typeof(SectionItem))
            {
                SectionItem output = new SectionItem();
                output.Deserialize(this.ContentValue);
                return output;
            }
            else
            {
                DocumentItem output = new DocumentItem();
                output.Deserialize(this.ContentValue);
                return output;
            }
        }
    }
}
