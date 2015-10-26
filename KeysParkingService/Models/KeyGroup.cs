using KPLibrary;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeysParkingService.Models
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