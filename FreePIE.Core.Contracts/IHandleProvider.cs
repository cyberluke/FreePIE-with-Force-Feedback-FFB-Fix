﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FreePIE.Core.Contracts
{
    public interface IHandleProvider
    {
        IntPtr Handle { get; }
    }
}
