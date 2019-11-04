﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobApp.Common.Business
{
    public class BusinessResult<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public T Value { get; set; }
    }
}
