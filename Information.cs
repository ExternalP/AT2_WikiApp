using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_WikiApp
{
    internal class Information
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


    }
}
