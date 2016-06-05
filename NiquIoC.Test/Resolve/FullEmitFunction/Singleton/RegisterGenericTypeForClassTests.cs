﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Singleton
{
    [TestClass]
    public class RegisterGenericTypeForClassTests
    {
        [TestMethod]
        public void RegisterSimpleGenericClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<GenericClass<EmptyClass>>().AsSingleton();

            var genericClass = c.Resolve<GenericClass<EmptyClass>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithClassWithNestedClass_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClass<SampleClass>>().AsSingleton();

            var genericClass = c.Resolve<GenericClass<SampleClass>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass);
            Assert.IsNotNull(genericClass.NestedClass.EmptyClass);
        }

        [TestMethod]
        public void RegisterGenericClassWithManyParameters_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClassWithManyParameters<EmptyClass, SampleClass>>().AsSingleton();

            var genericClass = c.Resolve<GenericClassWithManyParameters<EmptyClass, SampleClass>>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(genericClass);
            Assert.IsNotNull(genericClass.NestedClass1);
            Assert.IsNotNull(genericClass.NestedClass2);
            Assert.IsNotNull(genericClass.NestedClass2.EmptyClass);
            Assert.AreEqual(genericClass.NestedClass1, genericClass.NestedClass2.EmptyClass);
        }

        [TestMethod]
        public void RegisterManyGenericClasses_Success()
        {
            var c = new Container();
            c.RegisterType<EmptyClass>().AsSingleton();
            c.RegisterType<SampleClass>().AsSingleton();
            c.RegisterType<GenericClass<EmptyClass>>().AsSingleton();
            c.RegisterType<GenericClass<SampleClass>>().AsSingleton();

            var genericClass1 = c.Resolve<GenericClass<EmptyClass>>(Enums.ResolveKind.FullEmitFunction);
            var genericClass2 = c.Resolve<GenericClass<SampleClass>>(Enums.ResolveKind.FullEmitFunction);
            
            Assert.AreNotEqual(genericClass1, genericClass2);
            Assert.AreNotEqual(genericClass1.GetType(), genericClass2.GetType());
            Assert.AreEqual(genericClass1.NestedClass, genericClass2.NestedClass.EmptyClass);
            Assert.AreEqual(genericClass1.NestedClass.GetType(), genericClass2.NestedClass.EmptyClass.GetType());
        }
    }
}
