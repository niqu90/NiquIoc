﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerBasicTests
    {
        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void ClassNotRegistered_Fail()
        {
            var c = new Container();

            var sampleClass = c.Resolve2<EmptyClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void ClassWithConstructorWithoutParametersRegistered_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();

            var sampleClass = c.Resolve2<EmptyClass>();

            Assert.IsNotNull(sampleClass);
        }


        [TestMethod]
        public void ClassWithConstructorWithParameter_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve2<SampleClass>();

            Assert.IsNotNull(sampleClass);
            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(TypeNotRegisteredException))]
        public void MissingRegistration_Fail()
        {
            var c = new Container();
            c.RegisterType<SampleClass>();

            var sampleClass = c.Resolve2<SampleClass>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException))]
        public void ClassWithCycleInConstructor_Fail()
        {
            var c = new Container();
            c.RegisterType<SecondClassWithCycleInConstructor>();
            c.RegisterType<FirstClassWithCycleInConstructor>();

            var sampleClass = c.Resolve2<FirstClassWithCycleInConstructor>();

            Assert.IsNull(sampleClass);
        }

        [TestMethod]
        public void ClassRegisteredAsNotSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>();
            c.RegisterType<SampleClass>();

            var sampleClass1 = c.Resolve2<SampleClass>();
            var sampleClass2 = c.Resolve2<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void ClassRegisteredAsSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<EmptyClass>().AsSingleton();

            var sampleClass1 = c.Resolve2<SampleClass>();
            var sampleClass2 = c.Resolve2<SampleClass>();

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}