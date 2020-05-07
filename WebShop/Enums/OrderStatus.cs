using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Enums
{
    public enum OrderStatus : int
    {
        Paid = 0,
        Delivered = 1,
        Cancelled = 2,
        Failed = 3,
        Placed = 4,
        Pending = 5
    }
}