using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class Column
    {
        public Column()
        {
            Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public int DataTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual DataType DataType { get; set; } = null!;
        public virtual Table Table { get; set; } = null!;
        public virtual ICollection<Cell> Cells { get; set; }
    }
}
