﻿using Grace.DependencyInjection;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Containers.TestsGrace
{
    public abstract class TestCaseA : ITestCaseA
    {
        public abstract object Register(object container);

        public void Resolve(object container, int testCasesNumber)
        {
            if (container is IExportLocatorScope)
            {
                var c = (IExportLocatorScope)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Locate<ITestA>();
                }
            }
            else
            {
                // ReSharper disable once PossibleInvalidCastException
                var c = (DependencyInjectionContainer)container;

                for (var i = 0; i < testCasesNumber; i++)
                {
                    c.Locate<ITestA>();
                }
            }
        }
    }
}