using System;

namespace KPLibrary
{
    public class Key
    {
        public int Id
        { get; set; }

        public Guid GroupId
        { get; set; }

        public DateTime CreateTime
        { get; set; }

        public string SiteLink
        { get; set; }

        public string Login
        { get; set; }

        public string Password
        { get; set; }
    }
}