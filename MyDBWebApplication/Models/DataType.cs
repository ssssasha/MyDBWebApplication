using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MyDBWebApplication.Models
{
    public partial class DataType
    {
        public DataType()
        {
            Columns = new HashSet<Column>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display(Name = "Data type")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Column> Columns { get; set; }
    }
}
