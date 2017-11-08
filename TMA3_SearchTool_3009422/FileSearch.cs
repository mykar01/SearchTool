using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PorterStemmingAlgorithm;
using StringIntIndexWithCount;

namespace TMA3_SearchTool_3009422
{
    class FileSearch
    {
        // instance variables
        private HashSet<int> fileMatchResults;  // files that match query terms (and synonyms)
        private TermFrequency wordFrequencies;  // term frequencies of all words
        private QueryTerms queryTerms;  // query terms being searched for
        private StemmedTerms stemmedTerms; // index of which database 'word's relate to each stemmed term
        private TermFrequency termFrequencies;  //  term frequencies of query terms (and their synonyms)
        private Index invertedIndex;  // index of words -< fileId, count
        private Dictionary<int, int> totalTermHits;  // total number of term hits for each fileId (key: fileID, value: total term hits)
        private bool includeSynonyms;  // whether synonyms are to be included in search or not
        private bool useStemming;  // whether stemming should be used to widen the terms to be searched for

        // constructor
        public FileSearch(FileCollection files, QueryTerms queryTerms, StemmedTerms stemmedTerms, Index invertedIndex, TermFrequency wordFrequencies, bool includeSynonyms, bool useStemming)
        {
            this.fileMatchResults = null;
            this.queryTerms = queryTerms;
            this.stemmedTerms = stemmedTerms;
            this.invertedIndex = invertedIndex;
            this.wordFrequencies = wordFrequencies;
            this.includeSynonyms = includeSynonyms;
            this.useStemming = useStemming;
            totalTermHits = new Dictionary<int, int>();

            // get sets of files for each term, then intersect them to get result file list
            HashSet<string> wordsToFind;
            HashSet<int> fileIdMatches;

            foreach (string term in queryTerms.Terms())
            {
                wordsToFind = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                fileIdMatches = new HashSet<int>();
                string stemmedTerm = PorterStemmer.StemWord(term);

                // put term in wordsToFind
                wordsToFind.Add(queryTerms[term].Term);

                // if synonyms enabled and term has synonyms, add synonyms to wordsToFind
                if (includeSynonyms && queryTerms[term].HasSynonyms)
                {
                    foreach (string syn in queryTerms[term].Synonyms)
                    {
                        wordsToFind.Add(syn);
                    }
                }

                // if using stemming, add all terms that stem to the same value as term (stem terms)
                if (useStemming && stemmedTerms.ContainsKey(stemmedTerm))
                {
                    foreach (string stemTerm in stemmedTerms[stemmedTerm])
                    {
                        wordsToFind.Add(stemTerm);

                        // if synonyms enabled, add synonyms for all stem terms
                        if (includeSynonyms && queryTerms[term].HasStemSynonyms)
                        {
                            foreach (string stemSyn in queryTerms[term].StemSynonyms)
                            {
                                wordsToFind.Add(stemSyn);
                            }
                        }
                    }
                }

                // compile set of files that have term (or synonym)
                foreach (string word in wordsToFind)
                {
                    fileIdMatches.UnionWith(invertedIndex.GetSubindexKeys(word));  // add file ids linked to this word
                }

                // compile set of files that exist in each term's set (thus, all terms exist in resulting file set)
                if (fileMatchResults == null)
                {
                    fileMatchResults = new HashSet<int>(fileIdMatches); // create new set if one doesn't already exist
                }
                else
                {
                    fileMatchResults.IntersectWith(fileIdMatches); // intersect sets to leave just fileIds that exist in both sets
                }
            }

            // extract frequencies for relevant terms (and synonyms) to a separate TermFrequency object
            if (useStemming)
            {
                if (includeSynonyms)
                {
                    this.termFrequencies = new TermFrequency(this.wordFrequencies, this.queryTerms.TermsAndStemTermsWithSynonyms()); // stems and synonyms enabled
                }
                else
                {
                    this.termFrequencies = new TermFrequency(this.wordFrequencies, this.queryTerms.TermsAndStemTerms()); // stems enabled, no synonyms
                }
            }
            else
            {
                if (includeSynonyms)
                {
                    this.termFrequencies = new TermFrequency(this.wordFrequencies, this.queryTerms.TermsAndSynonyms()); // synonyms enabled, no stems
                }
                else
                {
                    this.termFrequencies = new TermFrequency(this.wordFrequencies, this.queryTerms.Terms()); // no stems or synonyms
                }
            }

            // compile dictionary of fileIDs and total term hits
            foreach (string foundTerm in termFrequencies.Terms())
            {
                foreach (int fileId in invertedIndex.GetSubindexKeys(foundTerm))
                {
                    if (fileMatchResults.Contains(fileId))  // if current fileID is in fileMatchResults..
                    {
                        if (!totalTermHits.ContainsKey(fileId))
                        {
                            totalTermHits.Add(fileId, invertedIndex.GetSubindexValue(foundTerm, fileId)); // term not already in totalTermHits: add term key with hit count value
                        }
                        else
                        {
                            totalTermHits[fileId] += invertedIndex.GetSubindexValue(foundTerm, fileId); // term already in totalTermHits: increase value for that key by the hit count
                        }
                    }
                }
            }
        }

        // MatchList
        // Returns int array of fileIds of the files that match the query terms (and their synonyms)
        public int[] MatchList()
        {
            return this.fileMatchResults.ToArray();
        }

        // MatchListDesc
        // returns int array of fileIds of the files that match the query terms (and their synonyms) sorted by descending order of total term hits
        public int[] MatchListDesc()
        {
            SortedSet<int> frequencies = new SortedSet<int>(totalTermHits.Values.Distinct());
            Dictionary<int, HashSet<int>> freqOfTermHits = new Dictionary<int, HashSet<int>>();

            // create Dictionary with total term hits as key and SortedSet of fileIds with that frequency as value
            foreach (int currentHitCount in frequencies)
            {
                freqOfTermHits.Add(currentHitCount, new HashSet<int>());
            }

            // add fileIds into the value set of the appropriate frequency
            foreach (int fileId in fileMatchResults)
            {
                int hitCount = totalTermHits[fileId];
                freqOfTermHits[hitCount].Add(fileId);
            }

            // create List of fileIds in descending order of total term hits
            List<int> fileIdsDesc = new List<int>();
            foreach (int freq in frequencies.Reverse())
            {
                foreach (int fileId in freqOfTermHits[freq])
                {
                    fileIdsDesc.Add(fileId);
                }
            }

            return fileIdsDesc.ToArray();
        }

        // MatchCount
        // Returns number of file matches found
        public int MatchCount()
        {
            return this.fileMatchResults.Count;
        }

        // TermFrequencyList
        // Returns string for displaying list of term frequencies as vertical list
        public string TermFrequencyList()
        {
            StringBuilder frequencyList = new StringBuilder();

            // put max frequency terms into frequency list
            frequencyList.Append("Word(s) with highest frequency in all files:" + Environment.NewLine);
            frequencyList.Append(this.wordFrequencies.MaxTermFrequencyString());
            frequencyList.Append(Environment.NewLine + Environment.NewLine);

            // add query term frequency display string
            if (this.includeSynonyms)
            {
                frequencyList.Append("Query terms and synonyms in descending order of frequency:");
            }
            else
            {
                frequencyList.Append("Query terms in descending order of frequency:");
            }
            frequencyList.Append(Environment.NewLine);
            frequencyList.Append(this.termFrequencies.TermFrequencyList());

            return frequencyList.ToString();
        }
    }
}
