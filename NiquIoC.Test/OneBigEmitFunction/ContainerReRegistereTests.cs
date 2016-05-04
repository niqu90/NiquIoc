﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.OneBigEmitFunction
{
    [TestClass]
    public class ContainerReRegistereTests
    {
        [TestMethod]
        public void ClassReRegisteredFromSingletonToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromSingletonToTransient_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>().AsTransient();
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromTransientToSingleton_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToInstance_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            var emptyClass3 = new EmptyClass();
            c.RegisterInstance(emptyClass3);
            var emptyClass4 = c.Resolve2<EmptyClass>();
            var emptyClass5 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreEqual(emptyClass4, emptyClass5);
            Assert.AreNotEqual(emptyClass, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterType<EmptyClass>(() => emptyClass);
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromInstanceToObjectFactory_Success()
        {
            var c = new Container();
            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass, emptyClass1);
            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromObjectFactoryToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass2, emptyClass3);
        }

        [TestMethod]
        public void ClassReRegisteredFromSingletonToObjectFactory_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            c.RegisterType<EmptyClass>(() => new EmptyClass());
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreEqual(emptyClass1, emptyClass2);
            Assert.AreNotEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }

        [TestMethod]
        public void ClassReRegisteredFromTransientToInstance_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsTransient();
            var emptyClass1 = c.Resolve2<EmptyClass>();
            var emptyClass2 = c.Resolve2<EmptyClass>();

            var emptyClass = new EmptyClass();
            c.RegisterInstance(emptyClass);
            var emptyClass3 = c.Resolve2<EmptyClass>();
            var emptyClass4 = c.Resolve2<EmptyClass>();

            Assert.AreNotEqual(emptyClass1, emptyClass2);
            Assert.AreEqual(emptyClass, emptyClass3);
            Assert.AreEqual(emptyClass3, emptyClass4);
            Assert.AreNotEqual(emptyClass1, emptyClass3);
            Assert.AreNotEqual(emptyClass1, emptyClass4);
        }
    }
}