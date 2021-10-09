﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Template.Data.Extensions;
using System.Text;
using Template.Domain.Entities;

namespace Template.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static ModelBuilder SeedData(this ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User { Id = Guid.Parse("c7dce21b-d207-4869-bf5f-08cb138bb919"), Name = "User Default", Email = "userdefault@template.com", DateCreated = new DateTime(2020,2,2), IsDeleted = false, DateUpdated = null }
                );

            return builder;
        }
    }
}