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

    internal class PriorityReference
    {
        [JsonInclude]
        private string Key {  get; set; }

        [JsonInclude]
        private int Priority {  get; set; }

        public PriorityReference(string key)
        {
            this.Key = key;
            this.Priority = 0;
        }

        public PriorityReference(string key, int priority)
        {
            this.Key = key;
            this.Priority = priority;
        }

        private void assignKeyFrom(KeyedItem source)
        {
            this.Key = source.GetKey();
        }

        public void updatePriority(int priority)
        {
            this.Priority = priority;
        }

        public int getPriority()
        {
            return this.Priority;
        }

        public string getKey()
        {
            return this.Key;
        }

        public void updatePriority(int priority)
        {
            this.Priority = priority;
        }


    }
}
