using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PorterStemmingAlgorithm;

namespace TMA3_SearchTool_3009422
{
    class QueryTerm
    {
        // instance variables
        private readonly string term;  // a specific query term
        private SortedSet<string> synonyms;  // synonyms related to the query term
        private SortedSet<string> stemTerms;  // terms that stem to the same value that the query term stems to
        private SortedSet<string> stemSynonyms;  // combined synonyms of each of the stemTerms

        // constructors
        public QueryTerm(string term, string[] synonyms) // with synonyms
        {
            this.term = term;
            this.synonyms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (string synonym in synonyms)
            {
                this.synonyms.Add(synonym);
            }
            this.stemTerms = null;
            this.stemSynonyms = null;
        }

        public QueryTerm(string term) // without synonyms
        {
            this.term = term;
            this.synonyms = null;
            this.stemTerms = null;
            this.stemSynonyms = null;
        }

        // Term property
        public string Term
        {
            get { return this.term; }
        }

        // Synonyms property
        public string[] Synonyms
        {
            get { return this.synonyms.ToArray(); }
        }

        // HasSynonyms property
        public bool HasSynonyms
        {
            get
            {
                if (this.synonyms != null)
                {
                    return true;
                }
                return false;
            }
        }

        // ContainsSynonym
        public bool ContainsSynonym(string synonym)
        {
            if (this.synonyms != null && this.synonyms.Contains(synonym))
            {
                return true;
            }
            return false;
        }

        // StemTerm property
        // returns the value that the receiver's term stems to
        public string TermStem
        {
            get { return PorterStemmer.StemWord(this.term); }
        }

        // StemTerms property
        // returns string array of stem terms (stemTerms)
        public string[] StemTerms
        {
            get { return this.stemTerms.ToArray(); }
        }

        // AddStemTerm
        // adds the given term to the list of stem terms (stemTerms)
        public void AddStemTerm(string stemTerm)
        {
            if (this.stemTerms == null) // create set if doesn't already exist
            {
                stemTerms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            if (!this.stemTerms.Contains(stemTerm))
            {
                this.stemTerms.Add(stemTerm);
            }
        }

        // StemSynonyms property
        public string[] StemSynonyms
        {
            get { return this.stemSynonyms.ToArray(); }
        }

        // AddStemSynonyms
        public void AddStemSynonyms(string[] stemSynonyms)
        {
            if (this.stemSynonyms == null) // create set if doesn't already exist
            {
                this.stemSynonyms = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            }

            foreach (string stemSyn in stemSynonyms)
            {
                if (!this.stemSynonyms.Contains(stemSyn))
                {
                    this.stemSynonyms.Add(stemSyn);
                }
            }
        }

        // HasStemSynonyms property
        public bool HasStemSynonyms
        {
            get
            {
                if (this.stemSynonyms != null)
                {
                    return true;
                }
                return false;
            }
        }

        // ContainsStemSynonym
        public bool ContainsStemSynonym(string stemSynonym)
        {
            if (this.stemSynonyms.Contains(stemSynonym))
            {
                return true;
            }
            return false;
        }
    }
}
