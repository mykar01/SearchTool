using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA3_SearchTool_3009422
{
    class TermFrequency
    {
        // instance variables
        private Dictionary<string, int> termFrequencies;  // collection of terms and their frequencies

        // constructors
        public TermFrequency()
        {
            this.termFrequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        }

        public TermFrequency(TermFrequency termFreq, string[] terms)
        {
            this.termFrequencies = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            foreach (string term in terms)
            {
                if (termFreq.Contains(term)) // skip if term not in TermFrequency object
                {
                    this.termFrequencies.Add(term, termFreq[term]);
                }
            }
        }

        // indexer
        // Accesses frequency values by index term
        public int this[string term]
        {
            get { return this.termFrequencies[term]; }
            set { this.termFrequencies[term] = value; }
        }

        // Contains
        // Returns true if the given term is in frequency list, else returns false
        public bool Contains(string term)
        {
            return this.termFrequencies.ContainsKey(term);
        }

        // Add Term Frequency
        public void Add(string term, int frequency)
        {
            this.termFrequencies.Add(term, frequency);
        }
        
        // Terms
        // Returns string array of all terms
        public string[] Terms()
        {
            return this.termFrequencies.Keys.ToArray();
        }

        // Frequency
        // Returns the frequency for a given term
        public int Frequency(string term)
        {
            return this.termFrequencies[term];
        }

        // Frequencies
        // Returns array of all frequency numbers in frequency list
        public int[] Frequencies()
        {
            return this.termFrequencies.Values.Distinct().ToArray();
        }

        // Max Frequency
        // Returns the highest frequency value
        public int MaxFrequency()
        {
            return this.termFrequencies.Values.Max();
        }

        // Max Frequency Terms
        // Returns the terms with the max frequency
        public string[] MaxFrequencyTerms()
        {
            SortedSet<string> maxTerms = new SortedSet<string>();
            int maxFreq = this.MaxFrequency();
            
            foreach (string term in this.termFrequencies.Keys)
            {
                if (this.termFrequencies[term] == maxFreq)
                {
                    maxTerms.Add(term);
                }
            }

            return maxTerms.ToArray();
        }

        // Terms with frequency
        // Returns string array of all terms with the given frequency
        public string[] TermsWithFrequency(int frequency)
        {
            SortedSet<string> terms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string term in this.termFrequencies.Keys)
            {
                if (Frequency(term) == frequency)
                {
                    terms.Add(term);
                }
            }

            return terms.ToArray();
        }

        // Max Term Frequency String
        // Returns string for displaying the word(s) with the highest frequency
        public string MaxTermFrequencyString()
        {
            StringBuilder maxFrequencyString = new StringBuilder();
            int termCount = 1;

            // put max frequency terms into frequency list
            foreach (string word in this.MaxFrequencyTerms())
            {
                maxFrequencyString.Append(word);
                if (termCount != this.MaxFrequencyTerms().Count())
                {
                    maxFrequencyString.Append(", ");
                }
                termCount++;
            }

            maxFrequencyString.AppendFormat(": {0}", this.MaxFrequency());

            return maxFrequencyString.ToString();
        }
        
        // Term Frequency List
        // Returns string for displaying list of term frequencies as vertical list
        public string TermFrequencyList()
        {
            SortedSet<int> frequencies = new SortedSet<int>();
            Dictionary<int, SortedSet<string>> freqOfTerms = new Dictionary<int, SortedSet<string>>();
            StringBuilder frequencyList = new StringBuilder();

            // create sorted set of frequencies
            foreach (int freq in this.Frequencies())
            {
                frequencies.Add(freq);
            }

            // create Dictionary with frequency as key and SortedSet of terms with that frequency as value
            // add frequency keys with empty SortedSets as values
            foreach (int freq in frequencies)
            {
                freqOfTerms.Add(freq, new SortedSet<string>(StringComparer.OrdinalIgnoreCase));

                // add terms into the value set of the appropriate frequency
                foreach (string term in this.TermsWithFrequency(freq))
                {
                    freqOfTerms[freq].Add(term);
                }
            }

            // construct display string
            foreach (int freq in frequencies.Reverse())
            {
                foreach (string term in freqOfTerms[freq])
                {
                    frequencyList.AppendFormat("{0}: {1}" + Environment.NewLine, term, freq);
                }
            }

            return frequencyList.ToString();
        }
    }
}
