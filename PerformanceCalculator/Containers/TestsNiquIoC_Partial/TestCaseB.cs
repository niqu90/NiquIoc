﻿using NiquIoC;
using NiquIoC.Enums;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Partial
{
    public abstract class TestCaseB : ITestCaseB
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.Resolve<ITestB>(ResolveKind.PartialEmitFunction);
            }
        }
    }
}