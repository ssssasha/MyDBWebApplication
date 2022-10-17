using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class Table
    {
        public Table()
        {
            Columns = new HashSet<Column>();
            Rows = new HashSet<Row>();
        }

        public int Id { get; set; }
        public int DatabaseId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Database Database { get; set; } = null!;
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
    }
}
