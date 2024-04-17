using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary.Structure
{
    public class PriorityReference
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

        public PriorityReference(KeyedItem source)
        {
            this.assignKeyFrom(source);
            this.Priority = 0;
        }

        public PriorityReference(KeyedItem source, int priority)
        {
            this.assignKeyFrom(source);
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
    }
}
