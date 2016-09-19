﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NiquIoC.Exceptions;
using NiquIoC.Test.ClassDefinitions;

namespace NiquIoC.Test.Resolve.FullEmitFunction.Transient
{
    [TestClass]
    public class BuildUpForInterfaceWithDependencyMethodTests
    {
        [TestMethod]
        public void InterfaceWithoutBuildUpWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            Assert.IsNotNull(sampleClass);
            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass1 = new SampleClassWithInterfaceDependencyMethod();
            ISampleClassWithInterfaceMethod sampleClass2 = new SampleClassWithInterfaceDependencyMethod();

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
        }

        [TestMethod]
        [ExpectedException(typeof(CycleForTypeException), "Appeared cycle when resolving constructor for object of type NiquIoC.Test.ClassDefinitions.SampleClassWithCycleInConstructorWithInterfaceDependencyMethod")]
        public void ResolveInterfaceWithCycleInConstructorWithClassDependencyMethodAfterBuildUpObjectOfThisInterface_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithCycleInConstructorWithInterfaceDependencyMethod>();
            ISampleClassWithInterfaceMethod sampleClass1 = new SampleClassWithCycleInConstructorWithInterfaceDependencyMethod(null);

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            var sampleClass2 = c.Resolve<SampleClassWithCycleInConstructorWithInterfaceDependencyMethod>(Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1);
            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNull(sampleClass2);
        }

        [TestMethod]
        public void BuildUpInterfaceWithoutDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethod sampleClass = new SampleClassWithoutInterfaceDependencyMethod();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithDependencyMethodWithReturnType_Failed()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            ISampleClassWithInterfaceMethodWithReturnType sampleClass = new SampleClassWithInterfaceDependencyMethodWithReturnType();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNull(sampleClass.EmptyClass);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass = new SampleClassWithManyInterfaceDependencyMethods();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithManyInterfaceDependencyMethods_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass1 = new SampleClassWithManyInterfaceDependencyMethods();
            ISampleClassWithManyInterfaceDependencyMethods sampleClass2 = new SampleClassWithManyInterfaceDependencyMethods();

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceAsParameter);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceAsParameter, sampleClass2.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void BuildUpInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass = new SampleClassWithManyInterfaceParametersInDependencyMethod();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.EmptyClass);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithManyInterfaceParametersInDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceAsParameter, SampleClassWithInterfaceAsParameter>();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass1 = new SampleClassWithManyInterfaceParametersInDependencyMethod();
            ISampleClassWithManyInterfaceParametersInDependencyMethod sampleClass2 = new SampleClassWithManyInterfaceParametersInDependencyMethod();

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass1.EmptyClass);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceAsParameter);
            Assert.IsNotNull(sampleClass2.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceAsParameter);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.EmptyClass, sampleClass2.EmptyClass);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceAsParameter, sampleClass2.SampleClassWithInterfaceAsParameter);
        }

        [TestMethod]
        public void BuildUpInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass = new SampleClassWithNestedInterfaceDependencyMethod();

            c.BuildUp(sampleClass, Enums.ResolveKind.FullEmitFunction);

            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass.SampleClassWithInterfaceDependencyMethod.EmptyClass);
        }

        [TestMethod]
        public void DifferentObjects_BuildUpInterfaceWithNestedInterfaceDependencyMethod_Success()
        {
            var c = new Container();
            c.RegisterType<IEmptyClass, EmptyClass>();
            c.RegisterType<ISampleClassWithInterfaceMethod, SampleClassWithInterfaceDependencyMethod>();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass1 = new SampleClassWithNestedInterfaceDependencyMethod();
            ISampleClassWithNestedInterfaceDependencyMethod sampleClass2 = new SampleClassWithNestedInterfaceDependencyMethod();

            c.BuildUp(sampleClass1, Enums.ResolveKind.FullEmitFunction);
            c.BuildUp(sampleClass2, Enums.ResolveKind.FullEmitFunction);
            
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass1.SampleClassWithInterfaceDependencyMethod.EmptyClass);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyMethod);
            Assert.IsNotNull(sampleClass2.SampleClassWithInterfaceDependencyMethod.EmptyClass);
            Assert.AreNotEqual(sampleClass1, sampleClass2);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyMethod, sampleClass2.SampleClassWithInterfaceDependencyMethod);
            Assert.AreNotEqual(sampleClass1.SampleClassWithInterfaceDependencyMethod.EmptyClass, sampleClass2.SampleClassWithInterfaceDependencyMethod.EmptyClass);
        }
    }
}