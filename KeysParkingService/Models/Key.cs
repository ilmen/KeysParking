using KeysParkingService.BisnessLogic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KeysParkingService.Models
{

    [Table("keys", Schema = "public")]
    public class Key : IGenericEntity<int>
    {
        [Key]
        [Column("KeyId")]
        public int Id
        { get; set; }

        [Column("GroupId")]
        public Guid GroupId
        { get; set; }

        [Column("CreateTime")]
        public DateTime CreateTime
        { get; set; }

        [Column("link")]
        public string SiteLink
        { get; set; }

        [Column("login")]
        public string Login
        { get; set; }

        [Column("password")]
        public string Password
        { get; set; }
    }
}