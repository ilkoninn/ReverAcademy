﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Exceptions
{
    public class DividedByZeroException : Exception
    {
        public DividedByZeroException(string message) : base(message) { }
    }
}
