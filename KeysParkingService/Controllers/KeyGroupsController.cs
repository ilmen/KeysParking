﻿using KeysParkingService.DataAccess;
using KeysParkingService.Models;
using KPLibrary;
using System;

namespace KeysParkingService.Controllers
{
    public class KeyGroupsController : UniversalRestController<KeyGroup, Guid>
    {
        private static GenericRestController<KeyGroup, Guid> GetRestController()
        {
            var dbContext = DbContextKeyParking.Instance;
            return new GenericRestController<KeyGroup, Guid>(dbContext, dbContext.KeyGroups);
        }

        public KeyGroupsController()
            : base(KeyGroupsController.GetRestController())
        {

        }
    }
}
