using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        /// <summary>
        /// An interface for all document item objects
        /// </summary>
        public abstract class DocumentItemTemplate
        {
            public abstract bool Deserialize(string source);
            public abstract override string ToString();
        }

    }
}
