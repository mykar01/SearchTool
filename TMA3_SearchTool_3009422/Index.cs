using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringIntIndexWithCount
{
    class Index
    {
        private Dictionary<string, Dictionary<int, int>> index;
        
        // constructor
        public Index()
        {
            index = new Dictionary<string, Dictionary<int, int>>(StringComparer.OrdinalIgnoreCase);
        }

        // indexer
        private Dictionary<int, int> this[string key]
        {
            get { return this.index[key]; }
        }

        // Update index
        public void UpdateIndex(string key, int value)
        {
            if (index.ContainsKey(key))
            {
                if (index[key].ContainsKey(value)) // key and value already exist
                {
                    index[key][value]++;
                }
                else // key exists, but not value
                {
                    index[key].Add(value, 1);
                }
            }
            else // key does not exist
            {
                Dictionary<int, int> subIndex = new Dictionary<int, int>();
                subIndex.Add(value, 1);
                index.Add(key, subIndex);
            }
        }

        // GetSubindexKeys
        // returns a HashSet of int keys from the subindex of the given index key
        public HashSet<int> GetSubindexKeys(string indexKey)
        {
            HashSet<int> subindexKeys = new HashSet<int>();
            if (index.ContainsKey(indexKey))
            {
                subindexKeys.UnionWith(new HashSet<int>(index[indexKey].Keys));
            }
            return subindexKeys;
        }

        // GetSubindexValue
        // returns the int value associated with the given subindex key
        public int GetSubindexValue(string indexKey, int subindexKey)
        {
            if (index.ContainsKey(indexKey) && index[indexKey].ContainsKey(subindexKey))
            {
                return index[indexKey][subindexKey];
            }
            return -1;
        }
    }
}
