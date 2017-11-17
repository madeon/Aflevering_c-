using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class SerialKey
    {

        private List<String> keys;

        public SerialKey()
        {
            Keys = new List<String>();
        }

        public List<string> Keys { get => keys; set => keys = value; }

        public void AddKey(string key)
        {
            Keys.Add(key);
        }


        /*
         * Generates a Globally Unique Identifier (GUID)
         * which is a 128-bit number and returns it as a string
         * https://en.wikipedia.org/wiki/Universally_unique_identifier
         */
        public string GenerateKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
