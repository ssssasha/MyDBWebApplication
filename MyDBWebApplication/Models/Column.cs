using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyDBWebApplication.Models
{
    public partial class Column
    {
        public Column()
        {
            Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }
        [Display(Name = "Table")]
        public int TableId { get; set; }
        [Display(Name = "Data type")]
        public int DataTypeId { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display(Name = "Column")]
        public string Name { get; set; } = null!;

        public virtual DataType? DataType { get; set; } = null!;
        public virtual Table? Table { get; set; } = null!;
        public virtual ICollection<Cell> Cells { get; set; }
    }
}
