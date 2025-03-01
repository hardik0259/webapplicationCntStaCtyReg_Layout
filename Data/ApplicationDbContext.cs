﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using webapplicationCntStaCtyReg_Layout.Models;

namespace webapplicationCntStaCtyReg_Layout.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base ("conStr")
        {

        }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Register> Registers { get; set; }

    }
}