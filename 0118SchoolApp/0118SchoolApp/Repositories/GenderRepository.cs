﻿using _0118SchoolApp.Data;
using _0118SchoolApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0118SchoolApp.Repositories
{
    public class GenderRepository : RepositoryBase<Gender>
    {
        public GenderRepository(DataContext context) : base(context)
        {

        }

    }
}
