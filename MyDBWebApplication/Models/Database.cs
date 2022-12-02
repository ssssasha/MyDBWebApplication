using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyDBWebApplication.Models
{
    public partial class Database
    {
        public Database()
        {
            Tables = new HashSet<Table>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "The field can't be empty")]
        [Display (Name="Database")]
        public string Name { get; set; } = null!;

        public virtual ICollection<Table> Tables { get; set; }
    }
}
