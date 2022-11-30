# AT2_WikiApp
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
 *  - FormWikiApp_Load(): call InitialiseCat() on load. */
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