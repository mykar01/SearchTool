using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWordList
{
    class StopWords
    {
        private HashSet<string> wordList;

        // constructor with default word list
        public StopWords()
        {
            wordList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // construct set of stop words using list of stop words retrieved from 'https://www.rans.nl/stopwords'
            string[] words = { "a", "about", "above", "after", "again", "against", "all", "am", "an", "and", "any", "are", "aren't", "as", "at", "be", "because", "been", "before", "being", "below", "between", "both", "but", "by", "can't", "cannot", "could", "couldn't", "did", "didn't", "do", "does", "doesn't", "doing", "don't", "down", "during", "each", "few", "for", "from", "further", "had", "hadn't", "has", "hasn't", "have", "haven't", "having", "he", "he'd", "he'll", "he's", "her", "here", "here's", "hers", "herself", "him", "himself", "his", "how", "how's", "i", "i'd", "i'll", "i'm", "i've", "if", "in", "into", "is", "isn't", "it", "it's", "its", "itself", "let's", "me", "more", "most", "mustn't", "my", "myself", "no", "nor", "not", "of", "off", "on", "once", "only", "or", "other", "ought", "our", "ours ", "ourselves", "out", "over", "own", "same", "shan't", "she", "she'd", "she'll", "she's", "should", "shouldn't", "so", "some", "such", "than", "that", "that's", "the", "their", "theirs", "them", "themselves", "then", "there", "there's", "these", "they", "they'd", "they'll", "they're", "they've", "this", "those", "through", "to", "too", "under", "until", "up", "very", "was", "wasn't", "we", "we'd", "we'll", "we're", "we've", "were", "weren't", "what", "what's", "when", "when's", "where", "where's", "which", "while", "who", "who's", "whom", "why", "why's", "with", "won't", "would", "wouldn't", "you", "you'd", "you'll", "you're", "you've", "your", "yours", "yourself", "yourselves" };
            for (int word = 0; word < words.Length; word++)
            {
                wordList.Add(words[word]);
            }
        }

        // constructor with custom word list
        public StopWords(string[] words)
        {
            wordList = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // construct set of stop words using provided string array
            for (int word = 0; word < words.Length; word++)
            {
                wordList.Add(words[word]);
            }
        }

        // IsStopWord
        public bool IsStopWord(string word)
        {
            if (wordList.Contains(word))
            {
                return true;
            }
            return false;
        }

        // GetStopWordArray
        public string[] GetStopWordArray()
        {
            return wordList.ToArray();
        }

        // Remove
        public void Remove(string word)
        {
            if (wordList.Contains(word))
            {
                wordList.Remove(word);
            }
        }
    }
}
