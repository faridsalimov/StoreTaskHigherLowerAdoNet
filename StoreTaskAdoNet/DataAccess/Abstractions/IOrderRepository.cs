﻿using StoreTaskAdoNet.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.DataAccess.Abstractions
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}
