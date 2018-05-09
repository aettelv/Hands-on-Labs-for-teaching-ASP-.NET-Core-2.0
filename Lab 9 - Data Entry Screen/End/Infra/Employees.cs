﻿using Core;
using System.Collections.Generic;
using System.Linq;

namespace Infra
{
    public class Employees
    {
        public static List<Employee> Get(SalesDbContext db)
        {
            return db.Employees.ToList();
        }
    }
}
