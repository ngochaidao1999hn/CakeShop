﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShop.Domain.Enums
{
    public enum OrderEnum
    {
        Pending,
        Processing,
        Shipping,
        Successful,
        Cancel
    }
}
