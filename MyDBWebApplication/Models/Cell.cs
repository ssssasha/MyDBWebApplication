using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class Cell
    {
        public int Id { get; set; }
        public int ColumnId { get; set; }
        public int RowId { get; set; }
        public string Value { get; set; } = null!;

        public virtual Column Column { get; set; } = null!;
        public virtual Row Row { get; set; } = null!;
    }
}
