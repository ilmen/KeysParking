using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KeysParkingService.Models
{
    [Table("keygroups", Schema = "public")]
    public class KeyGroup
    {
        [Key]
        [Column("GroupId")]
        public Guid GroupId
        { get; set; }

        [Column("Name")]
        public string Name
        { get; set; }
    }
}