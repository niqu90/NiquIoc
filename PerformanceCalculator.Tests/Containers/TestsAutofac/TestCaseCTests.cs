﻿using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceCalculator.Containers.TestsAutofac;
using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;

namespace PerformanceCalculator.Tests.Containers.TestsAutofac
{
    [TestClass]
    public class TestCaseCTests
    {
        [TestMethod]
        public void SingletonRegister_Success()
        {
            ITestCase testCase = new TestCaseC();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.SingletonRegister(cb);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();

            Assert.AreEqual(obj1, obj2);
            Helper.Check(obj1, true);
            Helper.Check(obj2, true);
        }

        [TestMethod]
        public void TransientRegister_Success()
        {
            ITestCase testCase = new TestCaseC();

            var cb = new ContainerBuilder();
            var c = (IContainer)testCase.TransientRegister(cb);

            var obj1 = c.Resolve<ITestC>();
            var obj2 = c.Resolve<ITestC>();

            Assert.AreNotEqual(obj1, obj2);
            Helper.Check(obj1, false);
            Helper.Check(obj2, false);
        }
    }
}