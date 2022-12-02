using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

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
        [Display(Name = "Database")]
        public int DatabaseId { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display(Name = "Table")]
        public string Name { get; set; } = null!;

        public virtual Database? Database { get; set; } = null!;
        public virtual ICollection<Column> Columns { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
    }
}
