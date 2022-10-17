using System;
using System.Collections.Generic;

namespace MyDBWebApplication.Models
{
    public partial class Database
    {
        public Database()
        {
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Table> Tables { get; set; }
    }
}
