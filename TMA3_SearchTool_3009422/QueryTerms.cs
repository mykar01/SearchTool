using PorterStemmingAlgorithm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMA3_SearchTool_3009422
{
    class QueryTerms
    {
        // instance variables
        private Dictionary<string, QueryTerm> queryTerms;  // collection of query terms (and synonyms, for those that have them) with query term as key, for querying specific QueryTerm objects
        private SortedSet<string> queryTermsAndSynonyms;  // collection of all distinct terms and synonyms for querying this QueryTerms object as a whole
        private StemmedTerms stemmedTerms;  // index of which database 'word's relate to each stemmed term

        // constructor
        public QueryTerms(StemmedTerms stemmedTerms)
        {
            this.queryTerms = new Dictionary<string, QueryTerm>(StringComparer.OrdinalIgnoreCase);
            this.queryTermsAndSynonyms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            this.stemmedTerms = stemmedTerms;
        }

        // indexer
        // Accesses QueryTerm objects by index term
        public QueryTerm this[string term]
        {
            get { return this.queryTerms[term]; }
        }

        // Terms
        public string[] Terms()
        {
            return this.queryTerms.Keys.ToArray();
        }

        // TermsAndSynonyms
        public string[] TermsAndSynonyms()
        {
            return this.queryTermsAndSynonyms.ToArray();
        }

        // TermsAndStemTerms
        // returns string array of all terms and all of the terms that stem to the same values
        public string[] TermsAndStemTerms()
        {
            SortedSet<string> terms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            terms.UnionWith(new SortedSet<string>(queryTerms.Keys));
            foreach (string term in queryTerms.Keys)
            {
                if (this.stemmedTerms.ContainsKey(this.queryTerms[term].TermStem))
                {
                    terms.UnionWith(this.stemmedTerms[this.queryTerms[term].TermStem]); // add terms that stem to same value as 'term' to terms set
                }
            }
            return terms.ToArray();
        }

        // TermsAndStemsWithSynonyms
        // returns string array of all terms (and their synonyms) and all of the terms that stem to the same values (and their synonyms)
        public string[] TermsAndStemTermsWithSynonyms()
        {
            SortedSet<string> terms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            terms.UnionWith(this.TermsAndStemTerms()); // add terms and stem terms
            foreach (string term in queryTerms.Keys)
            {
                if (this.queryTerms[term].HasSynonyms) 
                {
                    terms.UnionWith(this.queryTerms[term].Synonyms); // add synonyms
                }

                if (this.queryTerms[term].HasStemSynonyms)
                {
                    terms.UnionWith(this.queryTerms[term].StemSynonyms); // add stem synonyms
                }
            }
            return terms.ToArray();
        }

        // AddTerm
        public void AddTerm(string term)
        {
            this.queryTerms.Add(term, new QueryTerm(term));
            this.queryTermsAndSynonyms.Add(term);
        }

        // AddTermAndSynonyms
        public void AddTermAndSynonyms(string term, string[] synonyms)
        {
            this.queryTerms.Add(term, new QueryTerm(term, SingleWordsOnly(synonyms)));
            this.queryTermsAndSynonyms.Add(term);
            this.queryTermsAndSynonyms.UnionWith(SingleWordsOnly(synonyms));
        }

        // AddStemTerm
        public void AddStemTerm(string term, string stemTerm)
        {
            this.queryTerms[term].AddStemTerm(stemTerm);
            this.queryTermsAndSynonyms.Add(stemTerm);
        }

        // AddStemSynonyms
        public void AddStemSynonyms(string term, string[] stemSynonyms)
        {
            this.queryTerms[term].AddStemSynonyms(SingleWordsOnly(stemSynonyms));
            this.queryTermsAndSynonyms.UnionWith(SingleWordsOnly(stemSynonyms));
        }

        // ContainsTerm
        public bool ContainsTerm(string term)
        {
            if (this.queryTerms.ContainsKey(term))
            {
                return true;
            }
            return false;
        }

        // HasSynonyms
        public bool HasSynonyms(string term)
        {
            return this.queryTerms[term].HasSynonyms;
        }
        
        // SynonymsOf
        // Returns string array of the synonyms for the given term
        public string[] SynonymsOf(string term)
        {
            return this.queryTerms[term].Synonyms.ToArray();
        }

        // TermsWithSynonyms
        // Returns string array of all terms that have synonyms
        public string[] TermsWithSynonyms()
        {
            SortedSet<string> terms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (QueryTerm queryTerm in this.queryTerms.Values)
            {
                if (queryTerm.HasSynonyms)
                {
                    terms.Add(queryTerm.Term);
                }
            }
            return terms.ToArray();
        }

        // TermsWithSynonym
        // Returns string array of the terms that have the given synonym
        public string[] TermsWithSynonym(string synonym)
        {
            SortedSet<string> terms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (QueryTerm queryTerm in this.queryTerms.Values)
            {
                if (queryTerm.ContainsSynonym(synonym))
                {
                    terms.Add(queryTerm.Term);
                }
            }
            return terms.ToArray();
        }

        // SingleWordsOnly
        // returns string array of only the strings in the given string array that are single words (do not contain a space)
        private string[] SingleWordsOnly(string[] synonyms)
        {
            SortedSet<string> filteredSynonyms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string syn in synonyms)
            {
                if (!syn.Contains(" ")) // filter out synonyms with more than one word
                {
                    filteredSynonyms.Add(syn);
                }
            }
            return filteredSynonyms.ToArray();
        }
    }
}
