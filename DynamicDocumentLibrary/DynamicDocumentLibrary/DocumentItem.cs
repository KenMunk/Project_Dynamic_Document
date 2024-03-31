using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicDocumentLibrary
{
    namespace Structure
    {
        public class DocumentItem
        {
            private string key { get; set; }
            public string name { get; set; }
            public string value { get; set; }

            public DocumentItem()
            {

            }

            public DocumentItem(string key, string name, string value)
            {
                this.key = key;
                this.name = name;
                this.value = value;
            }

            public string toString() => string.Format("{0},{1},{2}",key, name, value);

            public bool setkey(string key)
            {
                if(this.key == null || this.key == string.Empty)
                {
                    this.key = key;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public string getkey()
            {
                if(this.key == null)
                {
                    return string.Empty;
                }
                else
                {
                    return this.key;
                }
            }

        }

    }
}
