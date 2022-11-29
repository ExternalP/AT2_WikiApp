namespace AT2_WikiApp
{
    partial class FormWikiApp
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tbDefinition = new System.Windows.Forms.TextBox();
            this.tbStructure = new System.Windows.Forms.TextBox();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.listViewRecords = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialogWiki = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogWiki = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpStructure = new System.Windows.Forms.GroupBox();
            this.radioLinear = new System.Windows.Forms.RadioButton();
            this.radioNonLinear = new System.Windows.Forms.RadioButton();
            this.statusStrip1.SuspendLayout();
            this.grpStructure.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Definition";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label5, "Data Structure Definition");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Structure";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label4, "Data Structure");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Category";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label3, "Data Structure Category");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label2, "Data Structure Name");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Search";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label1, "Search for record with same name as input.\r\nPress \'Enter\' in textbox to search.\r\n" +
        "(Will ignore case)");
            // 
            // statusStrip1
            // 
            this.statusStrip1.AccessibleName = "";
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statStripLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 385);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.ShowItemToolTips = true;
            this.statusStrip1.Size = new System.Drawing.Size(504, 22);
            this.statusStrip1.TabIndex = 28;
            // 
            // statStripLabel
            // 
            this.statStripLabel.AutoToolTip = true;
            this.statStripLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statStripLabel.Name = "statStripLabel";
            this.statStripLabel.Size = new System.Drawing.Size(489, 17);
            this.statStripLabel.Spring = true;
            this.statStripLabel.Text = "Status: New form opened";
            this.statStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(196, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(196, 93);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 23);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit Record";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(196, 64);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add Record";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(196, 35);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(85, 23);
            this.btnOpen.TabIndex = 24;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseMnemonic = false;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(196, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save to File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(23, 256);
            this.tbDefinition.MaxLength = 600;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(232, 96);
            this.tbDefinition.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbDefinition, "Definition field\r\n(Max Characters: 600)");
            // 
            // tbStructure
            // 
            this.tbStructure.Location = new System.Drawing.Point(58, 102);
            this.tbStructure.MaxLength = 50;
            this.tbStructure.Name = "tbStructure";
            this.tbStructure.Size = new System.Drawing.Size(121, 20);
            this.tbStructure.TabIndex = 3;
            this.toolTip1.SetToolTip(this.tbStructure, "Structure field\r\n(Max Characters: 50)");
            // 
            // tbCategory
            // 
            this.tbCategory.Location = new System.Drawing.Point(58, 76);
            this.tbCategory.MaxLength = 50;
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(121, 20);
            this.tbCategory.TabIndex = 2;
            this.toolTip1.SetToolTip(this.tbCategory, "Category field\r\n(Max Characters: 50)");
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(58, 50);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbName, "Double click here to clear all fields\r\n(Max Characters: 50)");
            this.tbName.DoubleClick += new System.EventHandler(this.tbName_DoubleClick);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.tbSearch.Location = new System.Drawing.Point(58, 11);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(121, 20);
            this.tbSearch.TabIndex = 17;
            this.toolTip1.SetToolTip(this.tbSearch, "Search for record with same name as input\r\nPress \'Enter\' to search");
            // 
            // listViewRecords
            // 
            this.listViewRecords.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory});
            this.listViewRecords.FullRowSelect = true;
            this.listViewRecords.GridLines = true;
            this.listViewRecords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewRecords.HideSelection = false;
            this.listViewRecords.Location = new System.Drawing.Point(287, 6);
            this.listViewRecords.MultiSelect = false;
            this.listViewRecords.Name = "listViewRecords";
            this.listViewRecords.Size = new System.Drawing.Size(205, 241);
            this.listViewRecords.TabIndex = 22;
            this.listViewRecords.UseCompatibleStateImageBehavior = false;
            this.listViewRecords.View = System.Windows.Forms.View.Details;
            this.listViewRecords.SelectedIndexChanged += new System.EventHandler(this.listRecords_SelectedIndexChanged);
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 120;
            // 
            // columnCategory
            // 
            this.columnCategory.Text = "Category";
            this.columnCategory.Width = 80;
            // 
            // openFileDialogWiki
            // 
            this.openFileDialogWiki.DefaultExt = "dat";
            this.openFileDialogWiki.FileName = "AT2_Info";
            this.openFileDialogWiki.Filter = "Binary files (*.dat)|*.dat";
            this.openFileDialogWiki.Title = "Load Wiki Records";
            // 
            // saveFileDialogWiki
            // 
            this.saveFileDialogWiki.DefaultExt = "dat";
            this.saveFileDialogWiki.FileName = "AT2_Info";
            this.saveFileDialogWiki.Filter = "Binary files (*.dat)|*.dat";
            this.saveFileDialogWiki.Title = "Save Wiki Records";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(191, 151);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search Record";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpStructure
            // 
            this.grpStructure.Controls.Add(this.radioLinear);
            this.grpStructure.Controls.Add(this.radioNonLinear);
            this.grpStructure.Location = new System.Drawing.Point(23, 169);
            this.grpStructure.Name = "grpStructure";
            this.grpStructure.Size = new System.Drawing.Size(90, 68);
            this.grpStructure.TabIndex = 35;
            this.grpStructure.TabStop = false;
            this.grpStructure.Text = "Queue Priority";
            this.toolTip1.SetToolTip(this.grpStructure, "Select which queue to enter\r\n(A queue must be selected to add an item)");
            // 
            // radioLinear
            // 
            this.radioLinear.AutoSize = true;
            this.radioLinear.Location = new System.Drawing.Point(6, 19);
            this.radioLinear.Name = "radioLinear";
            this.radioLinear.Size = new System.Drawing.Size(62, 17);
            this.radioLinear.TabIndex = 0;
            this.radioLinear.TabStop = true;
            this.radioLinear.Tag = "";
            this.radioLinear.Text = "Regular";
            this.toolTip1.SetToolTip(this.radioLinear, "Regular Queue: Default cost");
            this.radioLinear.UseVisualStyleBackColor = true;
            // 
            // radioNonLinear
            // 
            this.radioNonLinear.AutoSize = true;
            this.radioNonLinear.Location = new System.Drawing.Point(6, 42);
            this.radioNonLinear.Name = "radioNonLinear";
            this.radioNonLinear.Size = new System.Drawing.Size(62, 17);
            this.radioNonLinear.TabIndex = 1;
            this.radioNonLinear.TabStop = true;
            this.radioNonLinear.Text = "Express";
            this.toolTip1.SetToolTip(this.radioNonLinear, "Express Queue: Costs +15% extra");
            this.radioNonLinear.UseVisualStyleBackColor = true;
            // 
            // FormWikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(504, 407);
            this.Controls.Add(this.grpStructure);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDefinition);
            this.Controls.Add(this.tbStructure);
            this.Controls.Add(this.tbCategory);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.listViewRecords);
            this.Name = "FormWikiApp";
            this.Text = "Wiki Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWikiApp_FormClosing);
            this.Load += new System.EventHandler(this.FormWikiApp_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.grpStructure.ResumeLayout(false);
            this.grpStructure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statStripLabel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbDefinition;
        private System.Windows.Forms.TextBox tbStructure;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListView listViewRecords;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.OpenFileDialog openFileDialogWiki;
        private System.Windows.Forms.SaveFileDialog saveFileDialogWiki;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpStructure;
        private System.Windows.Forms.RadioButton radioLinear;
        private System.Windows.Forms.RadioButton radioNonLinear;
    }
}

