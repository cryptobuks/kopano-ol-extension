﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acacia.Stubs
{
    public interface ISignatures : IDisposable
    {
        ISignature Get(string name);
        ISignature Add(string name);
    }
}
