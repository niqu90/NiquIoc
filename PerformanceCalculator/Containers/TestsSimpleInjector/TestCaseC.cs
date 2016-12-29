﻿using PerformanceCalculator.Interfaces;
using PerformanceCalculator.TestCases;
using SimpleInjector;
using SimpleInjector.Extensions.LifetimeScoping;

namespace PerformanceCalculator.Containers.TestsSimpleInjector
{
    public class TestCaseC : ITestCase
    {
        public object SingletonRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestCa0, TestCa0>(Lifestyle.Singleton);
            c.Register<ITestCa1, TestCa1>(Lifestyle.Singleton);
            c.Register<ITestCa2, TestCa2>(Lifestyle.Singleton);
            c.Register<ITestCa3, TestCa3>(Lifestyle.Singleton);
            c.Register<ITestCa4, TestCa4>(Lifestyle.Singleton);
            c.Register<ITestCa5, TestCa5>(Lifestyle.Singleton);
            c.Register<ITestCa6, TestCa6>(Lifestyle.Singleton);
            c.Register<ITestCa7, TestCa7>(Lifestyle.Singleton);
            c.Register<ITestCa8, TestCa8>(Lifestyle.Singleton);
            c.Register<ITestCa9, TestCa9>(Lifestyle.Singleton);
            c.Register<ITestCa10, TestCa10>(Lifestyle.Singleton);

            c.Register<ITestCb0, TestCb0>(Lifestyle.Singleton);
            c.Register<ITestCb1, TestCb1>(Lifestyle.Singleton);
            c.Register<ITestCb2, TestCb2>(Lifestyle.Singleton);
            c.Register<ITestCb3, TestCb3>(Lifestyle.Singleton);
            c.Register<ITestCb4, TestCb4>(Lifestyle.Singleton);
            c.Register<ITestCb5, TestCb5>(Lifestyle.Singleton);
            c.Register<ITestCb6, TestCb6>(Lifestyle.Singleton);
            c.Register<ITestCb7, TestCb7>(Lifestyle.Singleton);
            c.Register<ITestCb8, TestCb8>(Lifestyle.Singleton);
            c.Register<ITestCb9, TestCb9>(Lifestyle.Singleton);
            c.Register<ITestCb10, TestCb10>(Lifestyle.Singleton);

            c.Register<ITestCc0, TestCc0>(Lifestyle.Singleton);
            c.Register<ITestCc1, TestCc1>(Lifestyle.Singleton);
            c.Register<ITestCc2, TestCc2>(Lifestyle.Singleton);
            c.Register<ITestCc3, TestCc3>(Lifestyle.Singleton);
            c.Register<ITestCc4, TestCc4>(Lifestyle.Singleton);
            c.Register<ITestCc5, TestCc5>(Lifestyle.Singleton);
            c.Register<ITestCc6, TestCc6>(Lifestyle.Singleton);
            c.Register<ITestCc7, TestCc7>(Lifestyle.Singleton);
            c.Register<ITestCc8, TestCc8>(Lifestyle.Singleton);
            c.Register<ITestCc9, TestCc9>(Lifestyle.Singleton);
            c.Register<ITestCc10, TestCc10>(Lifestyle.Singleton);

            c.Register<ITestC, TestC>(Lifestyle.Singleton);

            return c;
        }

        public object TransientRegister(object container)
        {
            var c = (Container)container;

            c.Register<ITestCa0, TestCa0>();
            c.Register<ITestCa1, TestCa1>();
            c.Register<ITestCa2, TestCa2>();
            c.Register<ITestCa3, TestCa3>();
            c.Register<ITestCa4, TestCa4>();
            c.Register<ITestCa5, TestCa5>();
            c.Register<ITestCa6, TestCa6>();
            c.Register<ITestCa7, TestCa7>();
            c.Register<ITestCa8, TestCa8>();
            c.Register<ITestCa9, TestCa9>();
            c.Register<ITestCa10, TestCa10>();

            c.Register<ITestCb0, TestCb0>();
            c.Register<ITestCb1, TestCb1>();
            c.Register<ITestCb2, TestCb2>();
            c.Register<ITestCb3, TestCb3>();
            c.Register<ITestCb4, TestCb4>();
            c.Register<ITestCb5, TestCb5>();
            c.Register<ITestCb6, TestCb6>();
            c.Register<ITestCb7, TestCb7>();
            c.Register<ITestCb8, TestCb8>();
            c.Register<ITestCb9, TestCb9>();
            c.Register<ITestCb10, TestCb10>();

            c.Register<ITestCc0, TestCc0>();
            c.Register<ITestCc1, TestCc1>();
            c.Register<ITestCc2, TestCc2>();
            c.Register<ITestCc3, TestCc3>();
            c.Register<ITestCc4, TestCc4>();
            c.Register<ITestCc5, TestCc5>();
            c.Register<ITestCc6, TestCc6>();
            c.Register<ITestCc7, TestCc7>();
            c.Register<ITestCc8, TestCc8>();
            c.Register<ITestCc9, TestCc9>();
            c.Register<ITestCc10, TestCc10>();

            c.Register<ITestC, TestC>();

            return c;
        }

        public object PerThreadRegister(object container)
        {
            var c = (Container)container;

            c.Options.DefaultScopedLifestyle = new LifetimeScopeLifestyle();

            c.Register<ITestCa0, TestCa0>(Lifestyle.Scoped);
            c.Register<ITestCa1, TestCa1>(Lifestyle.Scoped);
            c.Register<ITestCa2, TestCa2>(Lifestyle.Scoped);
            c.Register<ITestCa3, TestCa3>(Lifestyle.Scoped);
            c.Register<ITestCa4, TestCa4>(Lifestyle.Scoped);
            c.Register<ITestCa5, TestCa5>(Lifestyle.Scoped);
            c.Register<ITestCa6, TestCa6>(Lifestyle.Scoped);
            c.Register<ITestCa7, TestCa7>(Lifestyle.Scoped);
            c.Register<ITestCa8, TestCa8>(Lifestyle.Scoped);
            c.Register<ITestCa9, TestCa9>(Lifestyle.Scoped);
            c.Register<ITestCa10, TestCa10>(Lifestyle.Scoped);

            c.Register<ITestCb0, TestCb0>(Lifestyle.Scoped);
            c.Register<ITestCb1, TestCb1>(Lifestyle.Scoped);
            c.Register<ITestCb2, TestCb2>(Lifestyle.Scoped);
            c.Register<ITestCb3, TestCb3>(Lifestyle.Scoped);
            c.Register<ITestCb4, TestCb4>(Lifestyle.Scoped);
            c.Register<ITestCb5, TestCb5>(Lifestyle.Scoped);
            c.Register<ITestCb6, TestCb6>(Lifestyle.Scoped);
            c.Register<ITestCb7, TestCb7>(Lifestyle.Scoped);
            c.Register<ITestCb8, TestCb8>(Lifestyle.Scoped);
            c.Register<ITestCb9, TestCb9>(Lifestyle.Scoped);
            c.Register<ITestCb10, TestCb10>(Lifestyle.Scoped);

            c.Register<ITestCc0, TestCc0>(Lifestyle.Scoped);
            c.Register<ITestCc1, TestCc1>(Lifestyle.Scoped);
            c.Register<ITestCc2, TestCc2>(Lifestyle.Scoped);
            c.Register<ITestCc3, TestCc3>(Lifestyle.Scoped);
            c.Register<ITestCc4, TestCc4>(Lifestyle.Scoped);
            c.Register<ITestCc5, TestCc5>(Lifestyle.Scoped);
            c.Register<ITestCc6, TestCc6>(Lifestyle.Scoped);
            c.Register<ITestCc7, TestCc7>(Lifestyle.Scoped);
            c.Register<ITestCc8, TestCc8>(Lifestyle.Scoped);
            c.Register<ITestCc9, TestCc9>(Lifestyle.Scoped);
            c.Register<ITestCc10, TestCc10>(Lifestyle.Scoped);

            c.Register<ITestC, TestC>(Lifestyle.Scoped);

            return c;
        }

        public object PerHttpContextRegister(object container)
        {
            throw new System.NotImplementedException();
        }

        public void Resolve(object container, int testCasesNumber, bool singleton)
        {
            var c = (Container)container;

            for (var i = 0; i < testCasesNumber; i++)
            {
                c.GetInstance<ITestC>();
            }
        }
    }
}