using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Name: Corin Little
 * ID: P453208
 * Date: 29/11/2022
 * Purpose: AT2 - Wiki Application */
namespace AT2_WikiApp
{
    class Information : IComparable<Information>
    {
        // Class variables
        private string dsName;
        private string dsCategory;
        private string dsStructure;
        private string dsDefinition;

        // Getters & setters for all variables
        public string gsDsName
        {
            get { return dsName; }
            set { dsName = value; }
        }

        public string gsDsCategory
        {
            get { return dsCategory; }
            set { dsCategory = value; }
        }

        public string gsDsStructure
        {
            get { return dsStructure; }
            set { dsStructure = value; }
        }

        public string gsDsDefinition
        {
            get { return dsDefinition; }
            set { dsDefinition = value; }
        }

        // Simple compare method to sort by dsName
        public int CompareTo(Information newInfo)
        {
            return this.dsName.CompareTo(newInfo.dsName);
        }
    }
}
