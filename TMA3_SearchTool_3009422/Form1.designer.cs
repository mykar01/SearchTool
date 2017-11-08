namespace TMA3_SearchTool_3009422
{
    partial class SearchTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchTool));
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtInputFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFileQuery = new System.Windows.Forms.Button();
            this.lblNumOfFileMatches = new System.Windows.Forms.Label();
            this.newWordsDataSet = new TMA3_SearchTool_3009422.NewWordsDataSet();
            this.wordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wordsTableAdapter = new TMA3_SearchTool_3009422.NewWordsDataSetTableAdapters.WordsTableAdapter();
            this.tableAdapterManager = new TMA3_SearchTool_3009422.NewWordsDataSetTableAdapters.TableAdapterManager();
            this.wordsBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wordsBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.wordsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddEntry = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddSyn = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddWord = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteEntry = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeleteWord = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUpdateEntry = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUpdateSyn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUpdateWord = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnQueryEntry = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQuerySyn = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtQueryWord = new System.Windows.Forms.TextBox();
            this.chkIncludeSynonyms = new System.Windows.Forms.CheckBox();
            this.txtFrequencies = new System.Windows.Forms.TextBox();
            this.lblSearchTime = new System.Windows.Forms.Label();
            this.lblAverageTime = new System.Windows.Forms.Label();
            this.lbxQueryFileList = new System.Windows.Forms.ListBox();
            this.btnRefreshIndex = new System.Windows.Forms.Button();
            this.chkUseStemming = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.newWordsDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingNavigator)).BeginInit();
            this.wordsBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(263, 156);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(86, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "Browse...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtInputFolder
            // 
            this.txtInputFolder.Location = new System.Drawing.Point(12, 158);
            this.txtInputFolder.Name = "txtInputFolder";
            this.txtInputFolder.Size = new System.Drawing.Size(245, 20);
            this.txtInputFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Folder to search:";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(87, 185);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(170, 20);
            this.txtQuery.TabIndex = 2;
            this.txtQuery.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuery_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Search terms:";
            // 
            // btnFileQuery
            // 
            this.btnFileQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileQuery.Location = new System.Drawing.Point(263, 211);
            this.btnFileQuery.Name = "btnFileQuery";
            this.btnFileQuery.Size = new System.Drawing.Size(86, 23);
            this.btnFileQuery.TabIndex = 6;
            this.btnFileQuery.Text = "Search";
            this.btnFileQuery.UseVisualStyleBackColor = true;
            this.btnFileQuery.Click += new System.EventHandler(this.btnFileQuery_Click);
            // 
            // lblNumOfFileMatches
            // 
            this.lblNumOfFileMatches.AutoSize = true;
            this.lblNumOfFileMatches.Location = new System.Drawing.Point(11, 241);
            this.lblNumOfFileMatches.Name = "lblNumOfFileMatches";
            this.lblNumOfFileMatches.Size = new System.Drawing.Size(64, 13);
            this.lblNumOfFileMatches.TabIndex = 10;
            this.lblNumOfFileMatches.Text = "Files found: ";
            // 
            // newWordsDataSet
            // 
            this.newWordsDataSet.DataSetName = "NewWordsDataSet";
            this.newWordsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordsBindingSource
            // 
            this.wordsBindingSource.DataMember = "Words";
            this.wordsBindingSource.DataSource = this.newWordsDataSet;
            // 
            // wordsTableAdapter
            // 
            this.wordsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.UpdateOrder = TMA3_SearchTool_3009422.NewWordsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.WordsTableAdapter = this.wordsTableAdapter;
            // 
            // wordsBindingNavigator
            // 
            this.wordsBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.wordsBindingNavigator.BindingSource = this.wordsBindingSource;
            this.wordsBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.wordsBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.wordsBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.wordsBindingNavigatorSaveItem});
            this.wordsBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.wordsBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.wordsBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.wordsBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.wordsBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.wordsBindingNavigator.Name = "wordsBindingNavigator";
            this.wordsBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.wordsBindingNavigator.Size = new System.Drawing.Size(653, 25);
            this.wordsBindingNavigator.TabIndex = 11;
            this.wordsBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // wordsBindingNavigatorSaveItem
            // 
            this.wordsBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.wordsBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("wordsBindingNavigatorSaveItem.Image")));
            this.wordsBindingNavigatorSaveItem.Name = "wordsBindingNavigatorSaveItem";
            this.wordsBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.wordsBindingNavigatorSaveItem.Text = "Save Data";
            this.wordsBindingNavigatorSaveItem.Click += new System.EventHandler(this.wordsBindingNavigatorSaveItem_Click);
            // 
            // wordsDataGridView
            // 
            this.wordsDataGridView.AutoGenerateColumns = false;
            this.wordsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wordsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.wordsDataGridView.DataSource = this.wordsBindingSource;
            this.wordsDataGridView.Location = new System.Drawing.Point(0, 28);
            this.wordsDataGridView.Name = "wordsDataGridView";
            this.wordsDataGridView.Size = new System.Drawing.Size(348, 101);
            this.wordsDataGridView.TabIndex = 99;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Word";
            this.dataGridViewTextBoxColumn1.HeaderText = "Word";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Synonyms";
            this.dataGridViewTextBoxColumn2.HeaderText = "Synonyms";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddEntry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtAddSyn);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAddWord);
            this.groupBox1.Location = new System.Drawing.Point(384, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(253, 109);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Entry";
            // 
            // btnAddEntry
            // 
            this.btnAddEntry.Location = new System.Drawing.Point(19, 72);
            this.btnAddEntry.Name = "btnAddEntry";
            this.btnAddEntry.Size = new System.Drawing.Size(222, 23);
            this.btnAddEntry.TabIndex = 11;
            this.btnAddEntry.Text = "Add Entry";
            this.btnAddEntry.UseVisualStyleBackColor = true;
            this.btnAddEntry.Click += new System.EventHandler(this.btnAddEntry_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Synonyms:";
            // 
            // txtAddSyn
            // 
            this.txtAddSyn.Location = new System.Drawing.Point(85, 46);
            this.txtAddSyn.Name = "txtAddSyn";
            this.txtAddSyn.Size = new System.Drawing.Size(156, 20);
            this.txtAddSyn.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Word:";
            // 
            // txtAddWord
            // 
            this.txtAddWord.Location = new System.Drawing.Point(85, 20);
            this.txtAddWord.Name = "txtAddWord";
            this.txtAddWord.Size = new System.Drawing.Size(156, 20);
            this.txtAddWord.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeleteEntry);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtDeleteWord);
            this.groupBox2.Location = new System.Drawing.Point(384, 143);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(253, 79);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete Entry";
            // 
            // btnDeleteEntry
            // 
            this.btnDeleteEntry.Location = new System.Drawing.Point(19, 46);
            this.btnDeleteEntry.Name = "btnDeleteEntry";
            this.btnDeleteEntry.Size = new System.Drawing.Size(222, 23);
            this.btnDeleteEntry.TabIndex = 13;
            this.btnDeleteEntry.Text = "Delete Entry";
            this.btnDeleteEntry.UseVisualStyleBackColor = true;
            this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Word:";
            // 
            // txtDeleteWord
            // 
            this.txtDeleteWord.Location = new System.Drawing.Point(85, 20);
            this.txtDeleteWord.Name = "txtDeleteWord";
            this.txtDeleteWord.Size = new System.Drawing.Size(156, 20);
            this.txtDeleteWord.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUpdateEntry);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtUpdateSyn);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtUpdateWord);
            this.groupBox3.Location = new System.Drawing.Point(384, 228);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 109);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Update Entry";
            // 
            // btnUpdateEntry
            // 
            this.btnUpdateEntry.Location = new System.Drawing.Point(19, 72);
            this.btnUpdateEntry.Name = "btnUpdateEntry";
            this.btnUpdateEntry.Size = new System.Drawing.Size(222, 23);
            this.btnUpdateEntry.TabIndex = 16;
            this.btnUpdateEntry.Text = "Update Entry";
            this.btnUpdateEntry.UseVisualStyleBackColor = true;
            this.btnUpdateEntry.Click += new System.EventHandler(this.btnUpdateEntry_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Synonyms:";
            // 
            // txtUpdateSyn
            // 
            this.txtUpdateSyn.Location = new System.Drawing.Point(85, 46);
            this.txtUpdateSyn.Name = "txtUpdateSyn";
            this.txtUpdateSyn.Size = new System.Drawing.Size(156, 20);
            this.txtUpdateSyn.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Word:";
            // 
            // txtUpdateWord
            // 
            this.txtUpdateWord.Location = new System.Drawing.Point(85, 20);
            this.txtUpdateWord.Name = "txtUpdateWord";
            this.txtUpdateWord.Size = new System.Drawing.Size(156, 20);
            this.txtUpdateWord.TabIndex = 14;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnQueryEntry);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtQuerySyn);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.txtQueryWord);
            this.groupBox4.Location = new System.Drawing.Point(384, 343);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(253, 148);
            this.groupBox4.TabIndex = 17;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Query Entry";
            // 
            // btnQueryEntry
            // 
            this.btnQueryEntry.Location = new System.Drawing.Point(19, 112);
            this.btnQueryEntry.Name = "btnQueryEntry";
            this.btnQueryEntry.Size = new System.Drawing.Size(222, 23);
            this.btnQueryEntry.TabIndex = 19;
            this.btnQueryEntry.Text = "Query Entry";
            this.btnQueryEntry.UseVisualStyleBackColor = true;
            this.btnQueryEntry.Click += new System.EventHandler(this.btnQueryEntry_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Synonyms:";
            // 
            // txtQuerySyn
            // 
            this.txtQuerySyn.Location = new System.Drawing.Point(85, 46);
            this.txtQuerySyn.Multiline = true;
            this.txtQuerySyn.Name = "txtQuerySyn";
            this.txtQuerySyn.ReadOnly = true;
            this.txtQuerySyn.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuerySyn.Size = new System.Drawing.Size(156, 60);
            this.txtQuerySyn.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(16, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Word:";
            // 
            // txtQueryWord
            // 
            this.txtQueryWord.Location = new System.Drawing.Point(85, 20);
            this.txtQueryWord.Name = "txtQueryWord";
            this.txtQueryWord.Size = new System.Drawing.Size(156, 20);
            this.txtQueryWord.TabIndex = 17;
            this.txtQueryWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQueryWord_KeyPress);
            // 
            // chkIncludeSynonyms
            // 
            this.chkIncludeSynonyms.AutoSize = true;
            this.chkIncludeSynonyms.Location = new System.Drawing.Point(143, 214);
            this.chkIncludeSynonyms.Name = "chkIncludeSynonyms";
            this.chkIncludeSynonyms.Size = new System.Drawing.Size(112, 17);
            this.chkIncludeSynonyms.TabIndex = 5;
            this.chkIncludeSynonyms.Text = "Include Synonyms";
            this.chkIncludeSynonyms.UseVisualStyleBackColor = true;
            // 
            // txtFrequencies
            // 
            this.txtFrequencies.Location = new System.Drawing.Point(12, 410);
            this.txtFrequencies.Multiline = true;
            this.txtFrequencies.Name = "txtFrequencies";
            this.txtFrequencies.ReadOnly = true;
            this.txtFrequencies.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFrequencies.Size = new System.Drawing.Size(336, 115);
            this.txtFrequencies.TabIndex = 8;
            // 
            // lblSearchTime
            // 
            this.lblSearchTime.AutoSize = true;
            this.lblSearchTime.Location = new System.Drawing.Point(116, 241);
            this.lblSearchTime.Name = "lblSearchTime";
            this.lblSearchTime.Size = new System.Drawing.Size(70, 13);
            this.lblSearchTime.TabIndex = 19;
            this.lblSearchTime.Text = "Search Time:";
            // 
            // lblAverageTime
            // 
            this.lblAverageTime.AutoSize = true;
            this.lblAverageTime.Location = new System.Drawing.Point(240, 241);
            this.lblAverageTime.Name = "lblAverageTime";
            this.lblAverageTime.Size = new System.Drawing.Size(76, 13);
            this.lblAverageTime.TabIndex = 20;
            this.lblAverageTime.Text = "Average Time:";
            // 
            // lbxQueryFileList
            // 
            this.lbxQueryFileList.FormattingEnabled = true;
            this.lbxQueryFileList.Location = new System.Drawing.Point(12, 257);
            this.lbxQueryFileList.Name = "lbxQueryFileList";
            this.lbxQueryFileList.Size = new System.Drawing.Size(336, 147);
            this.lbxQueryFileList.TabIndex = 7;
            this.lbxQueryFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxQueryFileList_MouseDoubleClick);
            // 
            // btnRefreshIndex
            // 
            this.btnRefreshIndex.Location = new System.Drawing.Point(263, 184);
            this.btnRefreshIndex.Name = "btnRefreshIndex";
            this.btnRefreshIndex.Size = new System.Drawing.Size(86, 23);
            this.btnRefreshIndex.TabIndex = 3;
            this.btnRefreshIndex.Text = "Refresh Index";
            this.btnRefreshIndex.UseVisualStyleBackColor = true;
            this.btnRefreshIndex.Click += new System.EventHandler(this.btnRefreshIndex_Click);
            // 
            // chkUseStemming
            // 
            this.chkUseStemming.AutoSize = true;
            this.chkUseStemming.Location = new System.Drawing.Point(38, 214);
            this.chkUseStemming.Name = "chkUseStemming";
            this.chkUseStemming.Size = new System.Drawing.Size(94, 17);
            this.chkUseStemming.TabIndex = 4;
            this.chkUseStemming.Text = "Use Stemming";
            this.chkUseStemming.UseVisualStyleBackColor = true;
            // 
            // SearchTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 536);
            this.Controls.Add(this.chkUseStemming);
            this.Controls.Add(this.btnRefreshIndex);
            this.Controls.Add(this.lbxQueryFileList);
            this.Controls.Add(this.lblAverageTime);
            this.Controls.Add(this.lblSearchTime);
            this.Controls.Add(this.txtFrequencies);
            this.Controls.Add(this.chkIncludeSynonyms);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.wordsDataGridView);
            this.Controls.Add(this.wordsBindingNavigator);
            this.Controls.Add(this.lblNumOfFileMatches);
            this.Controls.Add(this.btnFileQuery);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInputFolder);
            this.Controls.Add(this.btnSelectFolder);
            this.Name = "SearchTool";
            this.Text = "Search Tool";
            this.Load += new System.EventHandler(this.SearchTool_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newWordsDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingNavigator)).EndInit();
            this.wordsBindingNavigator.ResumeLayout(false);
            this.wordsBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordsDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtInputFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFileQuery;
        private System.Windows.Forms.Label lblNumOfFileMatches;
        private NewWordsDataSet newWordsDataSet;
        private System.Windows.Forms.BindingSource wordsBindingSource;
        private NewWordsDataSetTableAdapters.WordsTableAdapter wordsTableAdapter;
        private NewWordsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator wordsBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton wordsBindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView wordsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAddEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAddSyn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddWord;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteEntry;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeleteWord;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdateEntry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUpdateSyn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUpdateWord;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnQueryEntry;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtQuerySyn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtQueryWord;
        private System.Windows.Forms.CheckBox chkIncludeSynonyms;
        private System.Windows.Forms.TextBox txtFrequencies;
        private System.Windows.Forms.Label lblSearchTime;
        private System.Windows.Forms.Label lblAverageTime;
        private System.Windows.Forms.ListBox lbxQueryFileList;
        private System.Windows.Forms.Button btnRefreshIndex;
        private System.Windows.Forms.CheckBox chkUseStemming;
    }
}

