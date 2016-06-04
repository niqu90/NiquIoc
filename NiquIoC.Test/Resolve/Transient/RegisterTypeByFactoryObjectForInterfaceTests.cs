﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.Transient
{
    [TestClass]
    public class RegisterTypeByFactoryObjectForInterfaceTests
    {
        [TestMethod]
        public void FactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<ISampleClassWithInterfaceAsParameter>(() => new SampleClassWithInterfaceAsParameter(emptyClass));

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void FactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            ISampleClassWithInterfaceAsParameter sampleClass = new SampleClassWithInterfaceAsParameter(emptyClass);
            c.RegisterType<ISampleClassWithInterfaceAsParameter>(() => sampleClass);

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.AreEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(emptyClass, sampleClass1.EmptyClass);
            Assert.AreEqual(emptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnNewObject_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass>(() => new EmptyClass());
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        public void NestedFactoryObjectReturnTheSameObject_Success()
        {
            var c = new Container();
            IEmptyClass emptyClass = new EmptyClass();
            c.RegisterType<IEmptyClass>(() => emptyClass);
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();

            var sampleClass1 = c.Resolve<ISampleClassWithInterfaceAsParameter>();
            var sampleClass2 = c.Resolve<ISampleClassWithInterfaceAsParameter>();

            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }
    }
}