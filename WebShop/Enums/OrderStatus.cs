using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Enums
{
    public enum OrderStatus
    {
        Paid,
        Delivered,
        Cancelled,
        Failed,
        Placed,
        Pending
    }
}