using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyDBWebApplication.Models
{
    public partial class Cell
    {
        public int Id { get; set; }

        [Display(Name = "Column")]
        public int ColumnId { get; set; }
        [Display(Name = "Row")]
        public int RowId { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display(Name = "Value")]
        public string Value { get; set; } = null!;

        public virtual Column? Column { get; set; } = null!;
        public virtual Row? Row { get; set; } = null!;
    }
}
