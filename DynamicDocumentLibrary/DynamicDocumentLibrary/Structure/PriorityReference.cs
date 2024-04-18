using System.Text.Json;
using System.Text.Json.Serialization;

namespace DynamicDocumentLibrary.Structure
{
    /// <summary>
    /// A container class for keyed document item references 
    /// </summary>
    public class PriorityReference
    {
        /// <summary>
        /// The key reference of the Keyed item based item that is being
        /// referenced by this object
        /// </summary>
        [JsonInclude]
        private string Key {  get; set; }

        /// <summary>
        /// The priority level of this reference.  How priority is managed will
        /// be handled by the structure section classes and additional
        /// implementation since it can be used in multiple ways
        /// </summary>
        [JsonInclude]
        private int Priority {  get; set; }

        /// <summary>
        /// The default initialization of Priority Reference.  Made inaccessible
        /// in order to prevent improper use.
        /// <br><br></br></br>
        /// The reason why this is not accessible is that every priority
        /// reference is required to have a Key reference.  Without a key
        /// reference there would be a cascading set of issues related to
        /// locating references
        /// </summary>
        private PriorityReference()
        {
        }

        /// <summary>
        /// Initializes a priority reference object with a string reference to
        /// a Keyed Item object.  The purpose of this is to rebuild a reference
        /// to a keyed item object via JSON extraction in order to promote
        /// safe file operations
        /// <br><br></br></br>
        /// The default priority set my this initialization method is:
        /// <br></br>
        /// Priority = 0
        /// <br><br></br></br>
        /// </summary>
        /// <param name="key">A string reference to a keyed item
        /// derived object</param>
        public PriorityReference(string key)
        {
            this.Key = key;
            this.Priority = 0;
        }

        /// <summary>
        /// Initializes a new priority reference object with pre-defined key
        /// reference and priority setting 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="priority"></param>
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

        /// <summary>
        /// A JSON representation of a Priority Reference object.  Primary
        /// purpose of this method is for testing purposes as this object would
        /// not normally be serialized outside of a structure section or a test
        /// </summary>
        /// <returns>A json representation of this object</returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
