using System;
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
 *  - NO sort/swap methods use built-in */
namespace AT2_WikiApp
{
    public partial class FormWikiApp : Form
    {
        // Global List of data structures info.
        List<Information> Wiki = new List<Information>();
        // Set in StatusMsg() so window is shorter than current screen height
        private int maxWindowHeight;
        private string appendErrMsg = "";
        public FormWikiApp()
        {
            InitializeComponent();
        }

        // btn to add a valid record to Wiki & display it
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
            if (listViewInfo.SelectedIndices.Count > 0)
            {
                if (EditRecord(listViewInfo.SelectedIndices[0]))
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
            if (listViewInfo.SelectedIndices.Count > 0)
            {
                int selIndex = listViewInfo.SelectedIndices[0];
                DialogResult result = MessageBox.Show(("Are sure you want to delete "
                    + "the record for \"" + Wiki[selIndex].gsDsName
                    + "\" at index " + selIndex + "\n\nClick 'Yes' to delete the"
                    + " record\nClick 'No' to cancel deletion"),
                    "Confirm Deletion", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    DeleteRecord(selIndex);
                    ClearFields();
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
            // If no records in list ask want to save
            if (Wiki.Count == 0)
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

        // btn to load the records to the list by selecting a binary file
        private void btnOpen_Click(object sender, EventArgs e)
        {
            // If no records in list ask want to save
            if (Wiki.Count > 0)
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

        // btn to search list for name that matches tbSearch & if found 
        //   selects record(highlight) in listview displaying its details
        // Focuses & clear tbSearch after search (CASE SENSITIVE)
        private void btnSearch_Click(object sender, EventArgs e)
        {
            listViewInfo.SelectedIndices.Clear();
            if (!String.IsNullOrEmpty(tbSearch.Text))
            {
                Information myInfo = new Information();
                myInfo.gsDsName = tbSearch.Text;
                int matchIndex = Wiki.BinarySearch(myInfo);
                ClearFields();
                if (matchIndex > -1)
                {
                    // Selects a record in listview which is detected by
                    //   listRecords_SelectedIndexChanged() so the record is displayed
                    listViewInfo.Items[matchIndex].Selected = true;
                    StatusMsg("Match found for \"" + myInfo.gsDsName + "\" at index: "
                        + matchIndex, true);
                }
                else
                {
                    StatusMsg("No match found for \"" + myInfo.gsDsName + "\"", true);
                }
            }
            else
            {
                StatusMsg("ERROR Invalid Input: Value NOT searched"
                    + "\nReason: Search field was empty", true);
                ClearFields();
            }
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

        // On keypress in tbName prevents special character & numeric inputs
        private void tbName_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoSpecialChar(ref e);
        }

        // On keypress in tbDefinition prevents special character & numeric inputs
        private void tbDefinition_KeyPress(object sender, KeyPressEventArgs e)
        {
            NoSpecialChar(ref e);
        }

        // Prevents special character & numeric inputs
        private void NoSpecialChar(ref KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)
                && e.KeyChar != '.' && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Detects if a record is selected/unselected in the listview 
        //   & calls SelectRecord() to display its details
        private void listRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRecord();
        }

        // Displays list in listViewInfo sorted by name (Columns name & category)
        private void DisplayList()
        {
            // Sort List by name using IComparable
            Wiki.Sort();
            // Clear the ListView
            listViewInfo.Items.Clear();
            foreach (Information myInfo in Wiki)
            {
                ListViewItem myListView = new ListViewItem(myInfo.gsDsName);
                myListView.SubItems.Add(myInfo.gsDsCategory);
                listViewInfo.Items.Add(myListView);
            }
        }

        // Add new record to Wiki if valid
        private bool AddRecord()
        {
            bool wasAdded = false;
            string statMsg = "";
            // hasData = false if invalid field (stat-msg but still add record)
            // hasName: if false DONT add record
            bool hasData = true, validName = false;
            string missingField = "";

            if (String.IsNullOrEmpty(tbName.Text))
            {
                hasData = false;
                missingField += "Name, ";
            }
            else
            {
                // tbName_KeyPress prevents special & numeric inputs
                // No duplicates if ValidName == true
                validName = ValidName(tbName.Text);
            }
            if (String.IsNullOrEmpty(cbCategory.Text))
            {
                hasData = false;
                missingField += "Category, ";
            }
            // tbDefinition_KeyPress prevents special & numeric inputs
            if (String.IsNullOrEmpty(tbDefinition.Text))
            {
                hasData = false;
                missingField += "Definition, ";
            }
            // Gets the selected radio btn for Structure
            string newStructure = GetStructure();
            if (String.IsNullOrEmpty(newStructure))
            {
                hasData = false;
                missingField += "Structure, ";
            }

            // Checks if any inputs were invalid
            if (hasData == false)
            {
                statMsg += "ERROR Invalid Input: Item will NOT be added to the list."
                    + "\nReason: The following field(s) are empty/invalid: "
                    + missingField.Remove(missingField.Length - 2);
            }
            else if (validName == false)
            {
                tbName.Focus();
                tbName.SelectAll();
                statMsg += "ERROR Invalid Input: Record was NOT added"
                    + "\nReason: Duplicate names are NOT ALLOWED "
                    + "\nA record with the name: \"" + tbName.Text
                    + "\" already exists in the list";
            }

            // Set new Information object to inputs & add to list, if valid
            if (hasData == true && validName == true)
            {
                Information newInfo = new Information();
                newInfo.gsDsName = tbName.Text;
                newInfo.gsDsCategory = cbCategory.Text;
                newInfo.gsDsStructure = newStructure;
                newInfo.gsDsDefinition = tbDefinition.Text;
                Wiki.Add(newInfo);

                Wiki.Sort();
                wasAdded = true;
                statMsg = "Information for \"" + Wiki.Last().gsDsName
                    + "\" was added to the list (records: " + Wiki.Count + ")";
            }
            // Display message in status strip & true to word wrap
            StatusMsg(statMsg, true);
            return wasAdded;
        }

        // Edit record & update list if valid at sent index
        private bool EditRecord(int editIndex)
        {
            bool wasEditted = false;
            string statMsg = "", nameChange = "";
            // if false DONT edit record
            bool hasData = true, noDuplicate = true;
            string missingField = "";

            if (String.IsNullOrEmpty(tbName.Text))
            {
                hasData = false;
                missingField += "Name, ";
            }
            else if (String.Compare(Wiki[editIndex].gsDsName, tbName.Text, 
                StringComparison.OrdinalIgnoreCase) != 0)
            {
                // tbName_KeyPress prevents special & numeric inputs
                // No duplicates if ValidName == true
                noDuplicate = ValidName(tbName.Text);
                nameChange = "\nname was changed from \"" + Wiki[editIndex].gsDsName 
                    + "\" to \"" + tbName.Text + "\"";
            }
            if (String.IsNullOrEmpty(cbCategory.Text))
            {
                hasData = false;
                missingField += "Category, ";
            }
            // tbDefinition_KeyPress prevents special & numeric inputs
            if (String.IsNullOrEmpty(tbDefinition.Text))
            {
                hasData = false;
                missingField += "Definition, ";
            }
            // Gets the selected radio btn for Structure
            string newStructure = GetStructure();
            if (String.IsNullOrEmpty(newStructure))
            {
                hasData = false;
                missingField += "Structure, ";
            }

            // Checks if any inputs were invalid
            if (hasData == false)
            {
                statMsg += "ERROR Invalid Input: Item will NOT be editted."
                    + "\nReason: The following field(s) are empty/invalid: "
                    + missingField.Remove(missingField.Length - 2);
            }
            else if (noDuplicate == false)
            {
                tbName.Focus();
                tbName.SelectAll();
                statMsg += "ERROR Invalid Input: Record was NOT editted"
                    + "\nReason: Duplicate names are NOT ALLOWED "
                    + "\nA record with the name: \"" + tbName.Text
                    + "\" already exists at the list ";
            }

            // Edit selected record using inputs, if valid
            if (hasData == true && noDuplicate == true)
            {
                Wiki[editIndex].gsDsName = tbName.Text;
                Wiki[editIndex].gsDsCategory = cbCategory.Text;
                Wiki[editIndex].gsDsStructure = newStructure;
                Wiki[editIndex].gsDsDefinition = tbDefinition.Text;

                wasEditted = true;
                statMsg += "Record called \"" + Wiki[editIndex].gsDsName
                    + "\" was editted" + nameChange;
                Wiki.Sort();
            }
            // Display message in status strip & true to word wrap
            StatusMsg(statMsg, true);
            return wasEditted;
        }

        // Delete record after confirmation at sent index
        private void DeleteRecord(int delIndex)
        {
            string statMsg = "Deleted record for \"" + Wiki[delIndex].gsDsName
                + "\" that was located at index " + delIndex 
                + " (records: " + Wiki.Count + ")";
            Wiki.RemoveAt(delIndex);
            Wiki.Sort();
            StatusMsg(statMsg, true);
        }

        // Valid = 'true', if input Name valid(not in List) return 'true'.
        // Uses inverted(!) List.Exists() so 'false' if duplicate in List.
        private bool ValidName(string myName)
        {
            bool isValid = false;
            // (INVERTED) Uses the built-in List method .Exists(), Ignores case
            isValid = !Wiki.Exists(e => e.gsDsName.Equals(myName, 
                StringComparison.OrdinalIgnoreCase));
            return isValid;
        }

        // Returns string from select radio btn (Linear/Non-Linear).
        private string GetStructure()
        {
            string structure = null;
            foreach (RadioButton r in grpStructure.Controls)
            {
                if (r.Checked)
                {
                    structure = r.Text;
                }
            }
            return structure;
        }

        // Sends int to highlight/select a radio btn (gets list index)
        private int SetStructure(int lstIndex)
        {
            int count = 0;
            foreach (RadioButton r in grpStructure.Controls)
            {
                if (r.Text == Wiki[lstIndex].gsDsStructure)
                {
                    return count;
                }
                count++;
            }
            return -1;
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
            Font notSelectedFont = new Font(listViewInfo.Font, FontStyle.Regular);
            foreach (ListViewItem i in listViewInfo.Items)
            {
                i.Font = notSelectedFont;
            }
            // If it detects an item is selected make its name bold
            if (listViewInfo.SelectedIndices.Count != 0)
            {
                int selIndex = listViewInfo.SelectedIndices[0];
                listViewInfo.Items[selIndex].Font =
                    new Font(listViewInfo.Font, FontStyle.Bold);
                tbName.Text = Wiki[selIndex].gsDsName;
                cbCategory.Text = Wiki[selIndex].gsDsCategory;
                tbDefinition.Text = Wiki[selIndex].gsDsDefinition;
                grpStructure.Controls.OfType<RadioButton>()
                    .ElementAt(SetStructure(selIndex)).Checked = true;
            }
        }

        // Clears all fields including search (NOT listview)
        private void ClearFields()
        {
            tbSearch.Clear();
            tbName.Clear();
            cbCategory.SelectedIndex = -1;
            foreach (RadioButton r in grpStructure.Controls)
            {
                r.Checked = false;
            }
            tbDefinition.Clear();
        }

        // Populate ComboBox for categories from a simple text file on load.
        private void InitialiseCat()
        {
            string[] catArray;
            // Create file if doesn't exist
            if (!File.Exists(@".\categories.txt"))
            {
                File.Create(@".\categories.txt").Close();
                catArray = new string[]
                { "Array", "List", "Tree", "Graphs", "Abstract", "Hash" };
                File.WriteAllLines("categories.txt", catArray);
            }
            catArray = File.ReadAllLines("categories.txt");
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
                foreach (Information i in Wiki)
                {
                    bw.Write(i.gsDsName);
                    bw.Write(i.gsDsCategory);
                    bw.Write(i.gsDsStructure);
                    bw.Write(i.gsDsDefinition);
                }
                StatusMsg(Wiki.Count + " record/s were successfully saved to:\n" 
                    + filePath, true);
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

            // Clear current list by initialising again
            Wiki = new List<Information>();
            // Read data
            try
            {
                while (br.BaseStream.Position != br.BaseStream.Length)
                {
                    Information info = new Information();
                    info.gsDsName = br.ReadString();
                    info.gsDsCategory = br.ReadString();
                    info.gsDsStructure = br.ReadString();
                    info.gsDsDefinition = br.ReadString();
                    Wiki.Add(info);
                }
                StatusMsg("Loaded " + Wiki.Count + " record/s from:\n" + filePath, true);
            }
            catch (EndOfStreamException eof) // Catches the EOF
            {
                MessageBox.Show("EOF reached, no more data.");
            }
            catch (Exception fe)
            {
                MessageBox.Show(" ERROR: Cannot read data from file."
                + "\nFilepath: " + filePath + "\n\n" + fe.Message);
            }
            br.Close();
        }

        // On load calls InitialiseCat() sets InitialDirectory & status strip to display some tips
        private void FormWikiApp_Load(object sender, EventArgs e)
        {
            string initialPath = Path.Combine(Application.StartupPath, @"");
            saveFileDialogWiki.InitialDirectory = initialPath;
            openFileDialogWiki.InitialDirectory = initialPath;
            InitialiseCat();
            string idn = "\n         ";
            StatusMsg("Tips: " +
                "1. Press 'Open File' to load saved records." + idn +
                "2. Search is case sensitive." + idn +
                "3. Records with the same name cannot be added." + idn +
                "4. Clicking on a record will select it & show its details in the fields."
                + idn + "5. Double click the 'Name' field to clear all fields." + idn +
                "6. Records can't contain numeric or special characters.", false);
        }

        // On close asks to choose location & name to save the list (AT2_Info.dat)
        private void FormWikiApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If any records in list ask to save
            if (Wiki.Count > 0)
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
