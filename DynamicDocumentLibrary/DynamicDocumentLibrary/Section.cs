using System;
using System.Collections.Generic;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        public class Section:DocumentItem
        {
            private List<DocumentItem> contents;

            public Section()
            {
                contents = new List<DocumentItem>();
            }
        }
    }

}
