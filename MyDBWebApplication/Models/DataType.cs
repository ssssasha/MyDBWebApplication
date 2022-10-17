using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class DataType
    {
        public DataType()
        {
            Columns = new HashSet<Column>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Column> Columns { get; set; }
    }
}
