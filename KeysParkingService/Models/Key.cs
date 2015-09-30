using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KeysParkingService.Models
{

    [Table("keys", Schema = "public")]
    public class Key
    {
        [Key]
        [Column("id")]
        public int Id
        { get; set; }

        [Column("create_time")]
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