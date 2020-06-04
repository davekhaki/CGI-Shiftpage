using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CGI_Shiftpage.Models
{
    [Table("CGI-Shift")]
    public partial class CgiShift
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Column("skill")]
        [StringLength(255)]
        public string Skill { get; set; }
        [Column("time", TypeName = "datetime")]
        public DateTime Time { get; set; }
    }
}
