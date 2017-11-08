using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorterStemmingAlgorithm;

namespace TMA3_SearchTool_3009422
{
    class StemmedTerms
    {
        private Dictionary<string, SortedSet<string>> stemmedTerms; // index of which database 'word's relate to each stemmed term:  stemmedTerm -< word

        // constructor
        public StemmedTerms()
        {
            stemmedTerms = new Dictionary<string, SortedSet<string>>(StringComparer.OrdinalIgnoreCase);
        }

        // indexer
        public SortedSet<string> this[string stemmedTerm]
        {
            get { return stemmedTerms[stemmedTerm]; }
        }

        // ContainsKey
        public bool ContainsKey(string key)
        {
            if (stemmedTerms.ContainsKey(key))
            {
                return true;
            }
            return false;
        }

        // Add
        public void Add(string word)
        {
            string stemmedWord = PorterStemmer.StemWord(word);

            if (stemmedTerms.ContainsKey(stemmedWord))  // stemmedWord already in collection
            {
                stemmedTerms[stemmedWord].Add(word);
            }
            else // stemmedWord not in collection
            {
                SortedSet<string> termSet = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
                termSet.Add(word);
                stemmedTerms.Add(stemmedWord, termSet);
            }
        }
    }
}
