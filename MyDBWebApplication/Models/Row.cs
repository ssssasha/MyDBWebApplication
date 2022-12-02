using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyDBWebApplication.Models
{
    public partial class Row
    {
        public Row()
        {
            Cells = new HashSet<Cell>();
        }

        public int Id { get; set; }
        [Display(Name = "Table")]
        public int TableId { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display(Name = "Row number")]
        public int Number { get; set; }

        public virtual Table? Table { get; set; } = null!;
        public virtual ICollection<Cell> Cells { get; set; }
    }
}
