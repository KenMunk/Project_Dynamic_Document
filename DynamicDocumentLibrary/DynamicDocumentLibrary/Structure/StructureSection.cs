using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary.Structure
{
    public class StructureSection : KeyedItem
    {
        [JsonInclude]
        private List<string> keyReference;

        public StructureSection()
        {
            this.keyReference = new List<string>();
        }

        public StructureSection(string key)
        {
            this.keyReference = new List<string>();
            this.Key = key;
        }

    }
}
