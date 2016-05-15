﻿using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PerformanceTests.Classes;
using SimpleInjector;

namespace PerformanceTests.TestsSimpleInjector
{
    public class ClassA
    {
        private static readonly string _fileName = Directory.GetCurrentDirectory() + "" + DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss") + ".txt";

        [TestMethod]
        public void Resolve100_SingletonRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            SingletonRegister(c);
            Resolve(c, 100, true);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve10_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 10, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve100_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 100, false);
            c.Dispose();
        }

        [TestMethod]
        public void Resolve1000_TransientRegister()
        {
            Helper.WriteLine(_fileName, "SimpleInjector");

            var c = new Container();
            TransientRegister(c);
            Resolve(c, 1000, false);
            c.Dispose();
        }

        private void SingletonRegister(Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestA0, TestA0>(Lifestyle.Singleton);
            c.Register<ITestA1, TestA1>(Lifestyle.Singleton);
            c.Register<ITestA2, TestA2>(Lifestyle.Singleton);
            c.Register<ITestA3, TestA3>(Lifestyle.Singleton);
            c.Register<ITestA4, TestA4>(Lifestyle.Singleton);
            c.Register<ITestA5, TestA5>(Lifestyle.Singleton);
            c.Register<ITestA6, TestA6>(Lifestyle.Singleton);
            c.Register<ITestA7, TestA7>(Lifestyle.Singleton);
            c.Register<ITestA8, TestA8>(Lifestyle.Singleton);
            c.Register<ITestA9, TestA9>(Lifestyle.Singleton);
            c.Register<ITestA10, TestA10>(Lifestyle.Singleton);
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void TransientRegister(Container c)
        {
            var sw = new Stopwatch();

            sw.Start();
            c.Register<ITestA0, TestA0>();
            c.Register<ITestA1, TestA1>();
            c.Register<ITestA2, TestA2>();
            c.Register<ITestA3, TestA3>();
            c.Register<ITestA4, TestA4>();
            c.Register<ITestA5, TestA5>();
            c.Register<ITestA6, TestA6>();
            c.Register<ITestA7, TestA7>();
            c.Register<ITestA8, TestA8>();
            c.Register<ITestA9, TestA9>();
            c.Register<ITestA10, TestA10>();
            sw.Stop();

            Helper.WriteLine(_fileName, "Register: {0} Milliseconds.", sw.ElapsedMilliseconds);
            sw.Reset();
        }

        private void Resolve(Container c, int testCasesNumber, bool singleton)
        {
            var sw = new Stopwatch();

            sw.Start();
            var lastValue = c.GetInstance<ITestA10>();
            sw.Stop();

            Helper.Check(lastValue, true);

            for (var i = 0; i < testCasesNumber - 1; i++)
            {
                sw.Start();
                var test = c.GetInstance<ITestA10>();
                sw.Stop();

                if (singleton)
                {
                    Assert.AreEqual(test, lastValue);
                }
                else
                {
                    Assert.AreNotEqual(test, lastValue);
                }

                Helper.Check(test, true);
                lastValue = test;
            }

            Helper.WriteLine(_fileName, "{0} resolve: {1} Milliseconds.", testCasesNumber, sw.ElapsedMilliseconds);
        }
    }
}