﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Landlyst.DataHandling.Interfaces
{
    // interface for hashing.
    // if there is need for changing hashing type later
    public interface IHash
    {
        public byte[] GetHash(byte[] input);
    }
}
