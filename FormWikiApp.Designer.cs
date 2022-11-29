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
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCategory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.openFileDialogWiki = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogWiki = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpStructure = new System.Windows.Forms.GroupBox();
            this.radioLinear = new System.Windows.Forms.RadioButton();
            this.radioNonLinear = new System.Windows.Forms.RadioButton();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.grpStructure.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Definition";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.toolTip1.SetToolTip(this.label5, "Data Structure Definition");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 77);
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
            this.label2.Location = new System.Drawing.Point(20, 51);
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
            this.label1.Location = new System.Drawing.Point(14, 17);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 291);
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
            this.btnDelete.Location = new System.Drawing.Point(191, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 23);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete Record";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(191, 96);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 23);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit Record";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(191, 67);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 23);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add Record";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(191, 38);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(90, 23);
            this.btnOpen.TabIndex = 24;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseMnemonic = false;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(191, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 23);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save to File";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tbDefinition
            // 
            this.tbDefinition.Location = new System.Drawing.Point(23, 188);
            this.tbDefinition.MaxLength = 600;
            this.tbDefinition.Multiline = true;
            this.tbDefinition.Name = "tbDefinition";
            this.tbDefinition.Size = new System.Drawing.Size(246, 96);
            this.tbDefinition.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbDefinition, "Definition field\r\n(Max Characters: 600)");
            this.tbDefinition.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbDefinition_KeyPress);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(58, 48);
            this.tbName.MaxLength = 50;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 20);
            this.tbName.TabIndex = 1;
            this.toolTip1.SetToolTip(this.tbName, "Double click here to clear all fields\r\n(Max Characters: 50)");
            this.tbName.DoubleClick += new System.EventHandler(this.tbName_DoubleClick);
            this.tbName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbName_KeyPress);
            // 
            // tbSearch
            // 
            this.tbSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(255)))), ((int)(((byte)(226)))));
            this.tbSearch.Location = new System.Drawing.Point(58, 14);
            this.tbSearch.MaxLength = 50;
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(121, 20);
            this.tbSearch.TabIndex = 17;
            this.toolTip1.SetToolTip(this.tbSearch, "Search for record with same name as input\r\nPress \'Enter\' to search");
            // 
            // listViewInfo
            // 
            this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnCategory});
            this.listViewInfo.FullRowSelect = true;
            this.listViewInfo.GridLines = true;
            this.listViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewInfo.HideSelection = false;
            this.listViewInfo.Location = new System.Drawing.Point(287, 9);
            this.listViewInfo.MultiSelect = false;
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(205, 275);
            this.listViewInfo.TabIndex = 22;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            this.listViewInfo.View = System.Windows.Forms.View.Details;
            this.listViewInfo.SelectedIndexChanged += new System.EventHandler(this.listRecords_SelectedIndexChanged);
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
            this.openFileDialogWiki.Title = "Open Wiki List";
            // 
            // saveFileDialogWiki
            // 
            this.saveFileDialogWiki.DefaultExt = "dat";
            this.saveFileDialogWiki.FileName = "AT2_Info";
            this.saveFileDialogWiki.Filter = "Binary files (*.dat)|*.dat";
            this.saveFileDialogWiki.Title = "Save Wiki List";
            // 
            // grpStructure
            // 
            this.grpStructure.Controls.Add(this.radioLinear);
            this.grpStructure.Controls.Add(this.radioNonLinear);
            this.grpStructure.Location = new System.Drawing.Point(58, 104);
            this.grpStructure.Name = "grpStructure";
            this.grpStructure.Size = new System.Drawing.Size(108, 68);
            this.grpStructure.TabIndex = 35;
            this.grpStructure.TabStop = false;
            this.grpStructure.Text = "Structure";
            this.toolTip1.SetToolTip(this.grpStructure, "Select which the structure type.\r\n(A option must be selected to add an item)");
            // 
            // radioLinear
            // 
            this.radioLinear.AutoSize = true;
            this.radioLinear.Location = new System.Drawing.Point(8, 19);
            this.radioLinear.Name = "radioLinear";
            this.radioLinear.Size = new System.Drawing.Size(54, 17);
            this.radioLinear.TabIndex = 0;
            this.radioLinear.TabStop = true;
            this.radioLinear.Tag = "";
            this.radioLinear.Text = "Linear";
            this.toolTip1.SetToolTip(this.radioLinear, "Linear Data Structure");
            this.radioLinear.UseMnemonic = false;
            this.radioLinear.UseVisualStyleBackColor = true;
            // 
            // radioNonLinear
            // 
            this.radioNonLinear.AutoSize = true;
            this.radioNonLinear.Location = new System.Drawing.Point(8, 42);
            this.radioNonLinear.Name = "radioNonLinear";
            this.radioNonLinear.Size = new System.Drawing.Size(77, 17);
            this.radioNonLinear.TabIndex = 1;
            this.radioNonLinear.TabStop = true;
            this.radioNonLinear.Text = "Non-Linear";
            this.toolTip1.SetToolTip(this.radioNonLinear, "Non-Linear Data Structure");
            this.radioNonLinear.UseMnemonic = false;
            this.radioNonLinear.UseVisualStyleBackColor = true;
            // 
            // cbCategory
            // 
            this.cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(58, 74);
            this.cbCategory.MaxDropDownItems = 6;
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(121, 21);
            this.cbCategory.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cbCategory, "Choose a category from the list.");
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(191, 154);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 23);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search Record";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormWikiApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(504, 313);
            this.Controls.Add(this.cbCategory);
            this.Controls.Add(this.grpStructure);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label5);
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
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.listViewInfo);
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
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.ColumnHeader columnCategory;
        private System.Windows.Forms.OpenFileDialog openFileDialogWiki;
        private System.Windows.Forms.SaveFileDialog saveFileDialogWiki;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox grpStructure;
        private System.Windows.Forms.RadioButton radioLinear;
        private System.Windows.Forms.RadioButton radioNonLinear;
        private System.Windows.Forms.ComboBox cbCategory;
    }
}

