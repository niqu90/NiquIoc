﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Common;
using PerformanceCalculator.Containers.TestsStructureMap;
using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Tests.Containers.TestsStructureMap
{
    [TestClass]
    public class StructureMapPerformanceTests
    {
        private IPerformanceTest GetPerformance()
        {
            return new StructureMapPerformanceTest();
        }

        [TestMethod]
        public void DoTestA_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.A, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestA_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.A, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestB_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.B, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestB_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.B, RegistrationKind.Transient);
        }

        [TestMethod]
        public void DoTestC_Singleton_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.C, RegistrationKind.Singleton);
        }

        [TestMethod]
        public void DoTestC_Transient_Success()
        {
            var performance = GetPerformance();
            performance.RunTest(1, TestCaseName.C, RegistrationKind.Transient);
        }
    }
}
