using KPService.RestLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPService.Models
{
    [Table("keygroups", Schema = "public")]
    public class KeyGroup : IGenericEntity<Guid>
    {
        [Key]
        [Column("GroupId")]
        public Guid Id
        { get; set; }

        [Column("Name")]
        public string Name
        { get; set; }
    }
}