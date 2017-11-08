using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PorterStemmingAlgorithm;
using StringIntIndexWithCount;
using StopWordList;
using System.Threading;

namespace TMA3_SearchTool_3009422
{
    public partial class SearchTool : Form
    {
        private SortedSet<long> searchTimes; // records search times for calculating average time
        private StemmedTerms stemmedTerms; // index of which database 'word's relate to each stemmed term
        private StopWords stopWords;  // object that holds collection of stop words to ignore in stemming process
        private FileCollection fileCollection;  // object that holds index of files and their ids
        private Index invertedIndex;  // holds index of which files a word is in
        private TermFrequency wordFrequencies;  // term frequencies of all words
        private Thread refreshIndexThread;  // holds reference to thread that index refresh is running on

        public SearchTool()
        {
            InitializeComponent();
            searchTimes = new SortedSet<long>();
            stemmedTerms = new StemmedTerms();
            stopWords = new StopWords();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderPath = folderBrowserDialog1.SelectedPath;
                txtInputFolder.Text = folderPath;
                GenerateFileCollection();
                invertedIndex = null;
            }
        }

        private void btnRefreshIndex_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtInputFolder.Text))
            {
                GenerateFileCollection();

                if (fileCollection != null)
                {
                    // run GenerateInvertedIndex in its own thread
                    refreshIndexThread = new Thread(new ThreadStart(GenerateInvertedIndex));
                    refreshIndexThread.Start();
                }
            }
            else // invalid folder path entered
            {
                MessageBox.Show("Invalid folder path." + Environment.NewLine +
                                "Select or enter a valid folder path to index.");
            }
        }

        private void btnFileQuery_Click(object sender, EventArgs e)
        {
            bool includeSynonyms = chkIncludeSynonyms.Checked;
            bool useStemming = chkUseStemming.Checked;
            QueryTerms queryTerms;
            string[] terms;
            FileSearch fileSearch;

            // if refreshIndex is null, abort
            if (refreshIndexThread == null || invertedIndex == null)
            {
                MessageBox.Show("Click 'Refresh Index' to generate search index." + Environment.NewLine +
                                "Note: This may take several minutes to complete for large collections.");
                return;
            }

            // if refreshIndex thread is active, display "Try again later" MessageBox and abort
            if (refreshIndexThread.IsAlive)
            {
                MessageBox.Show("Index refreshing.  Try again later.");
                return;
            }
            
            // abort if folderPath inconsistent
            if (fileCollection == null || fileCollection.FolderPath != txtInputFolder.Text)
            {
                MessageBox.Show("Selected folder has changed.  Refresh Index before searching!" + Environment.NewLine +
                                "Note: This may take several minutes to complete for large collections.");
                return;
            }

            // clear old results
            lblNumOfFileMatches.Text = "Files found: ";
            lblSearchTime.Text = "Search Time: ";
            lblAverageTime.Text = "Average Time: ";
            lbxQueryFileList.Items.Clear();
            txtFrequencies.Clear();

            // if query string not empty
            if (!string.IsNullOrWhiteSpace(txtQuery.Text))
            {
                // start timing the search
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();

                // create object to hold the query terms (and synonyms)
                queryTerms = new QueryTerms(stemmedTerms);

                // get query terms from GUI
                terms = txtQuery.Text.Split(' '); // TODO: add code to handle potential punctuation marks?

                // load query terms (and synonyms) into queryTerms object
                foreach (string term in terms)
                {
                    if (!string.IsNullOrWhiteSpace(term) && !queryTerms.ContainsTerm(term)) // skip if empty term or term already added
                    {
                        NewWordsDataSet.WordsRow wordsRow = newWordsDataSet.Words.FindByWord(term); // get db record for term
                        if (wordsRow != null)  // if term has synonyms..
                        {
                            // add term and synonyms
                            string[] synonyms = wordsRow.Synonyms.ToString().Split(',');
                            queryTerms.AddTermAndSynonyms(term, synonyms);
                        }
                        else // just add term
                        {
                            queryTerms.AddTerm(term);
                        }

                        if (useStemming) 
                        {
                            // add other terms (and their synonyms) that stem to the same value as current term
                            string stemmedTerm = PorterStemmer.StemWord(term);
                            if (stemmedTerms.ContainsKey(stemmedTerm))
                            {
                                foreach (string stemTerm in stemmedTerms[stemmedTerm])
                                {
                                    if (stemTerm != term)  // skip the query term
                                    {
                                        queryTerms.AddStemTerm(term, stemTerm);
                                        wordsRow = newWordsDataSet.Words.FindByWord(stemTerm); // get db record for stemTerm
                                        if (wordsRow != null)  // if stemTerm has synonyms..
                                        {
                                            // add synonyms for stem term
                                            string[] stemSynonyms = wordsRow.Synonyms.ToString().Split(',');
                                            queryTerms.AddStemSynonyms(term, stemSynonyms);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                fileSearch = new FileSearch(fileCollection, queryTerms, stemmedTerms, invertedIndex, wordFrequencies, includeSynonyms, useStemming);

                // display result file list
                foreach (int id in fileSearch.MatchListDesc())
                {
                    lbxQueryFileList.Items.Add(fileCollection.FilePath(id));
                }

                // add number of file matches to label
                lblNumOfFileMatches.Text += fileSearch.MatchCount();

                // display list of term frequencies
                txtFrequencies.Text = fileSearch.TermFrequencyList();

                // stop timing search and display time in ms
                stopwatch.Stop();
                searchTimes.Add(stopwatch.ElapsedMilliseconds);
                lblSearchTime.Text += string.Format("{0}ms", stopwatch.ElapsedMilliseconds);
                lblAverageTime.Text += string.Format("{0}ms", Math.Ceiling(searchTimes.Average()));
            }
            else // query text is empty
            {
                MessageBox.Show("Please enter terms to be queried.");
            }
        }

        private void txtQuery_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextboxEnterToSearch(e, txtQuery, btnFileQuery);
        }

        private void wordsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.wordsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.newWordsDataSet);

        }

        // OnLoad #########################
        private void SearchTool_Load(object sender, EventArgs e)
        {
            // This line of code loads data into the 'newWordsDataSet.Words' table.
            this.wordsTableAdapter.Fill(this.newWordsDataSet.Words);

            // build stemmedTerms index
            foreach (NewWordsDataSet.WordsRow row in newWordsDataSet.Words.Rows)
            {
                string word = row["Word"].ToString();
                stemmedTerms.Add(word);
            }
            // TODO:  Consider extending to find stems of term synonyms (but not term stem synonyms)?

            // remove words in database from stopWords
            foreach (string word in stopWords.GetStopWordArray())
            {
                NewWordsDataSet.WordsRow wordsRow = newWordsDataSet.Words.FindByWord(word);
                if (wordsRow != null)
                {
                    stopWords.Remove(word);
                }
            }
        }

        private void btnAddEntry_Click(object sender, EventArgs e)
        {
            try
            {
                // create new row
                DataRow newRow = newWordsDataSet.Tables["Words"].NewRow();
                newRow["Word"] = txtAddWord.Text;
                newRow["Synonyms"] = txtAddSyn.Text;
                txtAddWord.Text = "";
                txtAddSyn.Text = "";

                // insert new row into database
                newWordsDataSet.Tables["Words"].Rows.Add(newRow);
                wordsTableAdapter.Update(newWordsDataSet);
                MessageBox.Show("New entry added to database!");
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error);
            }
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                NewWordsDataSet.WordsRow wordsRow = newWordsDataSet.Words.FindByWord(txtDeleteWord.Text);
                wordsRow.Delete();
                txtDeleteWord.Text = "";
                MessageBox.Show("Deleted row!");
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error);
            }
        }

        private void btnUpdateEntry_Click(object sender, EventArgs e)
        {
            try
            {
                NewWordsDataSet.WordsRow wordsRow = newWordsDataSet.Words.FindByWord(txtUpdateWord.Text);
                wordsRow.Synonyms = txtUpdateSyn.Text;
                txtUpdateWord.Text = "";
                txtUpdateSyn.Text = "";
                MessageBox.Show("Updated row!");
            }
            catch (Exception error)
            {
                MessageBox.Show("An error occured: " + error);
            }
        }

        private void btnQueryEntry_Click(object sender, EventArgs e)
        {
            NewWordsDataSet.WordsRow wordsRow = newWordsDataSet.Words.FindByWord(txtQueryWord.Text);
            if (wordsRow != null)
            {
                // display synonyms as a vertical list
                string[] synonyms = wordsRow.Synonyms.ToString().Split(',');
                string synString = "";
                foreach (string syn in synonyms)
                {
                    synString += syn + Environment.NewLine;
                }
                txtQuerySyn.Text = synString;
            }
            else
            {
                txtQuerySyn.Text = "No results";
            }
        }

        private void txtQueryWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextboxEnterToSearch(e, txtQueryWord, btnQueryEntry);
        }

        private void TextboxEnterToSearch(KeyPressEventArgs e, TextBox textbox, Button button)
        {
            if (e.KeyChar == 13) // if Enter pressed
            {
                if (!textbox.AcceptsReturn)
                {
                    button.PerformClick();
                    if (!string.IsNullOrWhiteSpace(textbox.Text)) // if query string not empty
                    {
                        e.Handled = true; // suppress error sound
                    }
                }
            }
        }

        private void lbxQueryFileList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = lbxQueryFileList.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                System.Diagnostics.Process.Start(lbxQueryFileList.SelectedItem.ToString());
            }
        }

        private void GenerateFileCollection()
        {
            string folderPath = txtInputFolder.Text;
            string[] files;

            // get files to test folder path
            try
            {
                files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            }
            catch (ArgumentException error)
            {
                MessageBox.Show("Invalid folder path:" + Environment.NewLine + error.Message);
                fileCollection = null;
                return;
            }
            catch (DirectoryNotFoundException error)
            {
                MessageBox.Show("Folder not found:" + Environment.NewLine + error.Message);
                fileCollection = null;
                return;
            }
            catch (IOException error)
            {
                MessageBox.Show("Search does not accept file paths:" + Environment.NewLine + error.Message);
                fileCollection = null;
                return;
            }

            // abort if no files found at folder path
            if (files.Length == 0)
            {
                MessageBox.Show("No readable files found at the folder path.");
                fileCollection = null;
                return;
            }

            // convert files (string array of file paths) to FileCollection object
            fileCollection = new FileCollection(folderPath, files);
        }

        private void GenerateInvertedIndex()
        {
            /* Test code
            // start timing the search
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            btnFileQuery.Enabled = false;
            */

            this.Invoke ((MethodInvoker) delegate() { RefreshIndexStarted(); });

            invertedIndex = new Index();
            wordFrequencies = new TermFrequency();

            // read through each word of each file and build the index
            for (int fileId = 0; fileId < fileCollection.Length; fileId++)
            {
                if (fileCollection[fileId].EndsWith(".txt") || !Path.HasExtension(fileCollection[fileId]))
                {
                    TextReader tr = null;
                    string myLine = "";

                    // read in file
                    using (tr = new StreamReader(fileCollection.FilePath(fileId)))
                    {
                        while ((myLine = tr.ReadLine()) != null)
                        {
                            string[] fileWords = myLine.Split(' ', ',', '.', '!', '?', ';', ':', '"', '(', ')'); // TODO: Add more punctuation marks?  Single-quote (') left out in case used as apostraphe
                            foreach (string word in fileWords) // check each word in file
                            {
                                if (!string.IsNullOrWhiteSpace(word)) // skip empty/null strings
                                {
                                    invertedIndex.UpdateIndex(word, fileId);

                                    // count word
                                    if (wordFrequencies.Contains(word)) // if already in collection, increment value
                                    {
                                        wordFrequencies[word]++;
                                    }
                                    else // not already in collection, so add it
                                    {
                                        wordFrequencies.Add(word, 1);
                                    }
                                }
                            }
                        }
                    }
                }
                // TODO: add code to parse through doc/docx, xls/xlsx & pdf
            }

            this.Invoke ((MethodInvoker) delegate () { RefreshIndexComplete(); });

            /* Test code
            //btnFileQuery.Enabled = true;

            // stop timing search and display time in ms
            stopwatch.Stop();
            searchTimes.Add(stopwatch.ElapsedMilliseconds);
            lblSearchTime.Text = "";
            lblSearchTime.Text += string.Format("{0}ms", stopwatch.ElapsedMilliseconds);
            */
        }

        private void RefreshIndexStarted()
        {
            lblNumOfFileMatches.Text = "Files found: ";
            lblSearchTime.Text = "Search Time: ";
            lbxQueryFileList.Items.Clear();
            txtFrequencies.Text = "Refreshing index.  Please wait...";
        }

        private void RefreshIndexComplete()
        {
            txtFrequencies.Text = "Index refresh complete!";
        }
    }
}
