﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/* Name: Corin Little
 * ID: P453208
 * Date: 29/11/2022
 * Purpose: AT2 - Wiki Application */
/* Case Study – Data Structures Wiki Application
 * Develop a wiki application using the AT1 prototype to catalogue Data 
 *  Structures using a List containing a class with the 4 fields Name, 
 *  Category, Structure & Definition  using a Window Forms Application.
 * Create a interface for the app & can save the input data to file.
 * Need to use GitHub version control for project.
 *  - 2 class: FormWikiApp.cs & Information.cs (Information is a simple class) */
/* Information class: Implements IComparable<T>
 *  - 5 private string fields with Setters/getters & CompareTo() for name.
 *  - Name(dsName), Category(dsCategory), Structure(dsStructure) 
 *      & Definition(dsDefinition). */
/* FormWikiApp class: 
 *  - List<Information> Wiki: Global List of data structures info.
 *  - Can add/edit/delete records
 *  - Prevent duplicates & filter out numeric/special character inputs.
 *  - (USE built-in) Binary search by Name which selects it & clears search field.
 *  - Create/save/load from/to binary file of the List (Choose location/name).
 *  - Selecting a record causes its data to be display in the 4 fields
 *  - Clear all 4 field boxes when name field is double clicked
 *  - Full error trapping & feedback messages. */
/* Extend Requirements: Q6 stuff
 *  - DisplayList(): Single method sorts & displays all list's name & category.
 *  - ValidName(): Checks for duplicates(.Exists())), get tbName, return bool.
 *  - GetStructure(): Returns string from select radio btn (Linear/Non-Linear).
 *  - SetStructure(): Send int index to highlight the correct radio btn.
 *  - InitialiseCat(): Populate ComboBox from a simple text file on load.
 *  - FormWikiApp_Load(): call InitialiseCat() on load.
 *  - (Maybe)btnEdit_Click(): Might need to auto save after btn pressed. */
/* Form Design:
 *  - ListView: Displays selectable records sorted by name (Columns name & category).
 *  - 2 TextBox: For Name & search.
 *  - Multi-line TextBox: For Definition.
 *  - ComboBox(array of 6): For Category (Array,List,Tree,Graphs,Abstract,Hash).
 *  - GroupBox(2 Radio btns): For Structure (Linear & Non-Linear).
 *  - 6 Buttons: To add, edit, delete, search records, save & open files.
 *  - Status strip to display error messages.*/
/* IMPORTANT:
 *  - At end of assessment doc is the Matrix used for this.
 *  - Q6.6 could be problematic (check notes for solutions).
 *  - NO sort/swap methods use built-in
 *  - Might need to auto save after Edit btn pressed. */
namespace AT2_WikiApp
{
    public partial class FormWikiApp : Form
    {
        // When using maxRecords for final index remember to -1 from it
        private static int maxRecords = 12;
        // Initialise the 2D array
        string[,] myRecordsArray = new string[maxRecords, 4];
        // Index of first null in array
        private int nullIndex = 0;
        // Set in StatusMsg() so window is shorter than current screen height
        private int maxWindowHeight;
        private string appendErrMsg = "";
        public FormWikiApp()
        {
            InitializeComponent();
        }

        // btn to add a valid record to myRecordsArray & display it
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddRecord())
            {
                ClearFields();
                tbName.Focus();
            }
            DisplayList();
        }

        // btn to edit the selected record if new field values are valid & display it
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // If no record selected output message that a record must be selected
            if (listViewRecords.SelectedIndices.Count > 0)
            {
                if (EditRecord(listViewRecords.SelectedIndices[0]))
                {
                    ClearFields();
                    tbName.Focus();
                    DisplayList();
                }
            }
            else
            {
                StatusMsg("Error: Record was NOT editted \nReason: No record "
                    + "was selected to edit", true);
            }
        }

        // btn to delete the selected record if confirmed & update listview
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // If no record selected output message that a record must be selected
            if (listViewRecords.SelectedIndices.Count > 0)
            {
                int selectedIndex = listViewRecords.SelectedIndices[0];
                DialogResult result = MessageBox.Show(("Are sure you want to delete "
                    + "the record called \"" + myRecordsArray[selectedIndex, 0]
                    + "\" at index " + selectedIndex + "\n\nClick 'Yes' to delete the"
                    + " record\nClick 'No' to cancel deletion"),
                    "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteRecord(selectedIndex);
                    ClearFields();
                    tbSearch.Focus();
                    tbSearch.SelectAll();
                    DisplayList();
                }
                else
                {
                    StatusMsg("Record deletion was cancelled", true);
                }
            }
            else
            {
                StatusMsg("Error: Record was NOT deleted \nReason: No record "
                    + "was selected to delete", true);
            }

        }

        // btn to save the list to a binary file choosing its location & name
        private void btnSave_Click(object sender, EventArgs e)
        {
            // If no records in array ask want to save
            if (nullIndex == 0)
            {
                DialogResult result = MessageBox.Show(("Currently no records are loaded."
                    + "\nAre you sure you want to save."),
                    "Begin Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            saveFileDialogWiki.FileName = "AT2_Info";
            if (saveFileDialogWiki.ShowDialog() == DialogResult.OK)
            {
                if (Path.GetExtension(saveFileDialogWiki.FileName).ToLower() != ".dat")
                {
                    saveFileDialogWiki.FileName += ".dat";
                }
                FileWriter(saveFileDialogWiki.FileName);
                saveFileDialogWiki.InitialDirectory = Path.GetDirectoryName(
                    saveFileDialogWiki.FileName);
            }
            DisplayList();
        }

        // btn to load the records to the array by selecting a binary file
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // If no records in array ask want to save
            if (nullIndex > 0)
            {
                DialogResult result = MessageBox.Show(("Loading a records file will "
                    + "overwrite current records."
                    + "\nAre you sure you want to load records from file."),
                    "Warning: Overwrite current records", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }
            }

            openFileDialogWiki.FileName = "AT2_Info";
            if (openFileDialogWiki.ShowDialog() == DialogResult.OK)
            {
                FileReader(openFileDialogWiki.FileName);
                openFileDialogWiki.InitialDirectory = Path.GetDirectoryName(
                    openFileDialogWiki.FileName);
            }
            DisplayList();
        }

        // brn to search list for name that matches tbSearch & if found selects
        //   record(highlight) in listview displaying its details
        // Focuses & clear tbSearch after search
        private void btnSearch_Click(object sender, EventArgs e)
        {
            listViewRecords.SelectedIndices.Clear();
            ClearFields();
            if (!String.IsNullOrEmpty(tbSearch.Text))
            {
                int matchIndex = SearchRecords(tbSearch.Text);
                if (matchIndex != -1)
                {
                    // Selects a record in listview which is detected by
                    //   listRecords_SelectedIndexChanged() so the record is displayed
                    listViewRecords.Items[matchIndex].Selected = true;
                    StatusMsg("Match found for \"" + tbSearch.Text + "\" at index: "
                        + matchIndex, true);
                }
                else
                {
                    StatusMsg("No match found for \"" + tbSearch.Text + "\"", true);
                }
            }
            else
            {
                StatusMsg("ERROR Invalid Input: Value NOT searched"
                    + "\nReason: Search field was empty", true);
            }
            tbSearch.Clear();
            tbSearch.Focus();
            tbSearch.SelectAll();
        }

        // If tbName is double clicked clear all 4 fields & focuses tbName
        private void tbName_DoubleClick(object sender, EventArgs e)
        {
            ClearFields();
            tbName.Focus();
            tbName.SelectAll();
            StatusMsg("All fields have been cleared", true);
        }

        // Detects if a record is selected/unselected in the listview 
        //   & calls SelectRecords() to display its details
        private void listRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRecord();
        }

        // Displays records in listViewRecords after sort
        private void DisplayList()
        {
            // Clear the list
            listViewRecords.Items.Clear();
            BubbleSort();
            for (int i = 0; i < nullIndex; i++)
            {
                // Error message if nullIndex is wrong & exit loop
                if (string.IsNullOrEmpty(myRecordsArray[i, 0]))
                {
                    appendErrMsg += "ERROR: nullIndex = " + nullIndex + " however index "
                        + i + " is null\n";
                    break;
                }
                ListViewItem listView1 = new ListViewItem(myRecordsArray[i, 0]);
                listView1.SubItems.Add(myRecordsArray[i, 1]);
                listViewRecords.Items.Add(listView1);
            }
        }

        // Add new record to myRecordsArray if valid
        private bool AddRecord()
        {
            bool wasAdded = false;
            string statMsg = "ERROR CANNOT Add Record: Already at max capacity"
                + "\nReason: Maxium of " + maxRecords + " records can be stored, "
                + "delete a record to add a new one";
            // Check if space in array
            if (nullIndex <= maxRecords - 1)
            {
                statMsg = "";
                // hasData = false if invalid field (stat-msg but still add record)
                // hasName: if false DONT add record
                bool hasName = true, hasData = true;
                int duplicateFound;
                string missingField = "";

                if (String.IsNullOrEmpty(tbName.Text))
                {
                    hasName = false;
                }
                if (String.IsNullOrEmpty(tbCategory.Text))
                {
                    hasData = false;
                    missingField = "Category, ";
                }
                if (String.IsNullOrEmpty(tbStructure.Text))
                {
                    hasData = false;
                    missingField += "Structure, ";
                }
                if (String.IsNullOrEmpty(tbDefinition.Text))
                {
                    hasData = false;
                    missingField += "Definition, ";
                }

                duplicateFound = SearchRecords(tbName.Text);
                if (hasName == false)
                {
                    tbName.Focus();
                    tbName.SelectAll();
                    statMsg += "ERROR Invalid Input: Record was NOT added"
                        + "\nReason: Name field CANNOT be empty";
                }
                else if (duplicateFound != -1)
                {
                    tbName.Focus();
                    tbName.SelectAll();
                    statMsg += "ERROR Invalid Input: Record was NOT added"
                        + "\nReason: Duplicate names are NOT ALLOWED "
                        + "\nA record with the name: \"" + tbName.Text
                        + "\" already exists at index " + duplicateFound;
                }

                // Add record to myRecordsArray[] if valid
                if (hasName == true && duplicateFound == -1)
                {
                    myRecordsArray[nullIndex, 0] = tbName.Text;
                    myRecordsArray[nullIndex, 1] = tbCategory.Text;
                    myRecordsArray[nullIndex, 2] = tbStructure.Text;
                    myRecordsArray[nullIndex, 3] = tbDefinition.Text;

                    wasAdded = true;
                    statMsg += "Record called \"" + myRecordsArray[nullIndex, 0]
                        + "\" was added (" + (nullIndex + 1) + "/" + maxRecords + " records)";
                    nullIndex++;
                    BubbleSort();
                    if (hasData == false)
                    {
                        statMsg += "\nThe following field(s) are empty: "
                            + missingField.Remove(missingField.Length - 2)
                            + "\nRemember to fill them in later\n";
                    }
                }
            }
            // Display message in status strip & true to word wrap
            StatusMsg(statMsg, true);
            return wasAdded;
        }

        // Edit record & update array if valid at sent index
        private bool EditRecord(int editIndex)
        {
            bool wasEditted = false;
            string statMsg = "", nameChange = "";
            // hasName: if false DONT edit record
            bool hasName = true;
            // if duplicateFound != -1 then a duplicate was found
            int duplicateFound = -1;

            if (String.Compare(myRecordsArray[editIndex, 0], tbName.Text,
                    StringComparison.OrdinalIgnoreCase) != 0)
            {
                duplicateFound = SearchRecords(tbName.Text);
                nameChange = "\nname was changed from \"" + myRecordsArray[editIndex, 0]
                    + "\" to \"" + tbName.Text + "\"";
            }
            if (String.IsNullOrEmpty(tbName.Text))
            {
                hasName = false;
                tbName.Focus();
                tbName.SelectAll();
                statMsg += "ERROR Invalid Input: Record was NOT editted"
                    + "\nReason: Name field CANNOT be empty";
            }
            else if (duplicateFound != -1)
            {
                tbName.Focus();
                tbName.SelectAll();
                statMsg += "ERROR Invalid Input: Record was NOT editted"
                    + "\nReason: Duplicate names are NOT ALLOWED "
                    + "\nA record with the name: \"" + tbName.Text
                    + "\" already exists at index " + duplicateFound;
            }

            // Edit record & update myRecordsArray[] if true
            if (hasName == true && duplicateFound == -1)
            {
                myRecordsArray[editIndex, 0] = tbName.Text;
                myRecordsArray[editIndex, 1] = tbCategory.Text;
                myRecordsArray[editIndex, 2] = tbStructure.Text;
                myRecordsArray[editIndex, 3] = tbDefinition.Text;

                wasEditted = true;
                statMsg += "Record called \"" + myRecordsArray[editIndex, 0]
                    + "\" was editted" + nameChange;
                BubbleSort();
            }
            // Display message in status strip & true to word wrap
            StatusMsg(statMsg, true);
            return wasEditted;
        }

        // Delete record after confirmation at sent index
        private void DeleteRecord(int delIndex)
        {
            string statMsg = "Deleted record called \"" + myRecordsArray[delIndex, 0]
                    + "\" that was located at index " + delIndex + " ("
                    + (nullIndex - 1) + "/" + maxRecords + " records)";
            for (int i = delIndex; i < nullIndex - 1; i++)
            {
                Swapper(i, (i + 1));
            }
            nullIndex--;
            myRecordsArray[nullIndex, 0] = null;
            myRecordsArray[nullIndex, 1] = null;
            myRecordsArray[nullIndex, 2] = null;
            myRecordsArray[nullIndex, 3] = null;
            StatusMsg(statMsg, true);
        }

        // Binary search of array to match searchTxt, return -1 if not found
        private int SearchRecords(string searchTxt)
        {
            int foundIndex = -1;
            int startIndex = -1;
            int finalIndex = nullIndex;
            bool flag = false;

            while (!flag && !((finalIndex - startIndex) <= 1))
            {
                int newIndex = (finalIndex + startIndex) / 2;
                // Compare: == if myRecordsArray[newIndex, 0] same position in 
                //   sort order as tbName.Text
                if (String.Compare(myRecordsArray[newIndex, 0], searchTxt,
                    StringComparison.OrdinalIgnoreCase) == 0)
                {
                    foundIndex = newIndex;
                    flag = true;
                }
                else
                {
                    // Compare: > if myRecordsArray[newIndex, 0] precedes 
                    //  tbName.Text's position in sort order 
                    if (String.Compare(myRecordsArray[newIndex, 0], searchTxt,
                        StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        finalIndex = newIndex;
                    }
                    // Compare: < if tbName.Text precedes 
                    //  myRecordsArray[newIndex, 0]'s position in sort order 
                    else
                    {
                        startIndex = newIndex;
                    }
                }
            }
            // Return -1 for no match found
            return foundIndex;
        }

        // @@@@@@@@@@@@@@@@___________NEEDS CODE____________@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // Checks for duplicates(.Exists())), get tbName, return bool.
        private bool ValidName(string myName)
        {
            //  Use the built in List<T> method "Exists"

        }

        // @@@@@@@@@@@@@@@@___________NEEDS CODE____________@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // Returns string from select radio btn (Linear/Non-Linear).
        private string GetStructure()
        {
            

        }

        // @@@@@@@@@@@@@@@@___________NEEDS CODE____________@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        // Send int index to highlight/select the correct radio btn.
        private int SetStructure(string myStructure)
        {
            // This is Q6.6 (check "AT2 - Q6-6 IMPORTANT NOTES.cs" for solution).

        }

        // Displays the status message after formating msg & strip
        private void StatusMsg(string statMsg, bool wrapTxt)
        {
            int originalHeight = statusStrip1.Height;
            // Strip text line NOT visible if >95 char for default size
            int maxLength = (int)(Convert.ToDouble(statStripLabel.Width) / 4.8) - 3;
            statMsg = (statMsg.Trim('\n') + "\n\n" + appendErrMsg.Trim('\n')).Trim('\n');
            // Manual word wrap for the status strip
            if (wrapTxt == true)
            {
                string[] newLines = statMsg.Split('\n');
                string msgParts = "";
                foreach (var line in newLines)
                {
                    string[] words = line.Split(' ');
                    var parts = new Dictionary<int, string>();
                    string part = string.Empty;
                    int partCounter = 0;
                    foreach (var word in words)
                    {
                        if (part.Length + word.Length < maxLength)
                            part += string.IsNullOrEmpty(part) ? word : " " + word;
                        else
                        {
                            parts.Add(partCounter, part);
                            part = word;
                            partCounter++;
                        }
                    }
                    parts.Add(partCounter, part);
                    foreach (var item in parts)
                        msgParts += item.Value + "\n";
                }
                statMsg = msgParts.Trim('\n');
            }
            statStripLabel.Text = statMsg;
            appendErrMsg = "";

            // maxWindowHeight set to 90% of current screen height
            maxWindowHeight = Screen.FromControl(this).Bounds.Height / 10 * 9;
            int newStripHeight = statusStrip1.Height - originalHeight;
            // Increase height of window so status strip isn't covering stuff
            if (this.Height + newStripHeight < maxWindowHeight)
                this.Height += statusStrip1.Height - originalHeight;
            else
                this.Height = maxWindowHeight;
        }

        // Outputs details of the record selected in the listview to their textboxes
        // Bolds only the selected item
        private void SelectRecord()
        {
            // Unbolds all items first so only selected item is bold
            Font notSelectedFont = new Font(listViewRecords.Font, FontStyle.Regular);
            for (int i = 0; i < nullIndex; i++)
            {
                listViewRecords.Items[i].Font = notSelectedFont;
            }
            // If it detects an item is selected make its name bold
            if (listViewRecords.SelectedIndices.Count != 0)
            {
                int selectedIndex = listViewRecords.SelectedIndices[0];
                listViewRecords.Items[selectedIndex].Font =
                    new Font(listViewRecords.Font, FontStyle.Bold);
                tbName.Text = myRecordsArray[selectedIndex, 0];
                tbCategory.Text = myRecordsArray[selectedIndex, 1];
                tbStructure.Text = myRecordsArray[selectedIndex, 2];
                tbDefinition.Text = myRecordsArray[selectedIndex, 3];
            }
        }

        // Clears all 4 fields (NOT tbSearch or listview)
        private void ClearFields()
        {
            tbName.Clear();
            tbCategory.Clear();
            tbStructure.Clear();
            tbDefinition.Clear();
        }

        // Populate ComboBox from a simple text file on load.
        private void InitialiseCat(string[] catArray)
        {
            foreach (string cat in catArray)
            {
                cbCategory.Items.Add(cat);
            }
        }

        // Records data is written to selected file (AT2_Info.dat)
        private void FileWriter(string filePath)
        {
            BinaryWriter bw;

            // Create the file
            try
            {
                bw = new BinaryWriter(new FileStream(filePath, FileMode.Create));
            }
            catch (Exception fe)
            {
                MessageBox.Show(" ERROR: Cannot write data to file."
                    + "\nFilepath: " + filePath + "\n\n" + fe.Message);
                return;
            }

            // Writing to file
            try
            {
                for (int i = 0; i < nullIndex; i++)
                {
                    bw.Write(myRecordsArray[i, 0]);
                    bw.Write(myRecordsArray[i, 1]);
                    bw.Write(myRecordsArray[i, 2]);
                    bw.Write(myRecordsArray[i, 3]);
                }
                StatusMsg(nullIndex + " record/s were successfully saved to:\n" + filePath, true);
            }
            catch (Exception fe)
            {
                MessageBox.Show(" ERROR: Cannot write data to file."
                    + "\nFilepath: " + filePath + "\n\n" + fe.Message);
            }

            bw.Close();
        }

        // Reading from selected file (AT2_Info.dat) 
        private void FileReader(string filePath)
        {
            BinaryReader br;
            try
            {
                br = new BinaryReader(new FileStream(filePath,
                    FileMode.Open));
            }
            catch (Exception fe)
            {
                MessageBox.Show(" ERROR: Cannot open file to read data from."
                    + "\nFilepath: " + filePath + "\n\n" + fe.Message);
                return;
            }

            // Clear current array by initialising again
            myRecordsArray = new string[maxRecords, 4];
            // Read data
            try
            {
                for (int i = 0; i < maxRecords; i++)
                {
                    // Exit loop if reached end of file
                    if (br.BaseStream.Position == br.BaseStream.Length)
                    { break; }
                    myRecordsArray[i, 0] = br.ReadString();
                    myRecordsArray[i, 1] = br.ReadString();
                    myRecordsArray[i, 2] = br.ReadString();
                    myRecordsArray[i, 3] = br.ReadString();
                    nullIndex = i;
                }
                nullIndex++;
                StatusMsg("Loaded " + nullIndex + " record/s from:\n" + filePath, true);
            }
            catch (EndOfStreamException eof) // Catches the EOF
            {
                MessageBox.Show("EOF reached, no more data.");
                nullIndex++;
            }
            catch (Exception fe)
            {
                MessageBox.Show(" ERROR: Cannot read data from file."
                + "\nFilepath: " + filePath + "\n\n" + fe.Message);
            }
            br.Close();
        }

        // On load sets InitialDirectory & status strip to display some tips
        private void FormWikiApp_Load(object sender, EventArgs e)
        {
            string initialPath = Path.Combine(Application.StartupPath, @"");
            saveFileDialogWiki.InitialDirectory = initialPath;
            openFileDialogWiki.InitialDirectory = initialPath;
            StatusMsg("Tips: " +
                "1. Press 'Load from File' to load saved records.\n         " +
                "2. Press the 'Enter' key in the 'Search' box to search input.\n" +
                "         3. Records with the same name cannot be added.\n" +
                "         4. Clicking on a record will select it & show its details " +
                "in the fields.\n         5. Double click the 'Name' field to clear " +
                "all 4 fields.", false);
            string[] catArray;
            // Create file if doesn't exist
            if (!File.Exists(@".\categories.txt"))
            {
                File.Create(@".\categories.txt").Close();
                catArray = new string[]
                { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" };
                File.WriteAllLines("categories.txt", catArray);
            }
            InitialiseCat(File.ReadAllLines("categories.txt"));
        }

        // On close asks to choose location & name to save the list (AT2_Info.dat)
        private void FormWikiApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If any records in array ask to save
            if (nullIndex != 0)
            {
                saveFileDialogWiki.FileName = "AT2_Info";
                if (saveFileDialogWiki.ShowDialog() == DialogResult.OK)
                {
                    if (Path.GetExtension(saveFileDialogWiki.FileName).ToLower() != ".dat")
                    {
                        saveFileDialogWiki.FileName += ".dat";
                    }
                    FileWriter(saveFileDialogWiki.FileName);
                    saveFileDialogWiki.InitialDirectory = Path.GetDirectoryName(
                        saveFileDialogWiki.FileName);
                }
            }
        }
    }
}
