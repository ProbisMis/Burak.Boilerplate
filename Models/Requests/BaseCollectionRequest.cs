﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Burak.Boilerplate.Models.Requests
{
    public class BaseCollectionRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 25;
    }
}
