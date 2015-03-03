using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace IBS.Data
{
    public class CheckBoxColumn
    {
        public CheckBoxColumn(DataColumn column)
        {
            this.column = column;
            this.Name = column.ColumnName;
            this.Index = column.Ordinal;
        }

        private DataColumn column;
        public string Name { get; private set; }
        public int Index { get; private set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
