﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterMoon.Core.Infrastructure
{
    public interface IStartupTask
    {
        void Execute();

        int Order { get; }
    }
}
