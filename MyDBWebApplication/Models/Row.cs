using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class Row
    {
        public Row()
        {
            Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }
        public int TableId { get; set; }
        public int Number { get; set; }

        public virtual Table Table { get; set; } = null!;
        public virtual ICollection<Cell> Cells { get; set; }
    }
}
