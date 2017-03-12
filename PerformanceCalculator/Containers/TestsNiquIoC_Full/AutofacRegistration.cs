﻿using PerformanceCalculator.Interfaces;

namespace PerformanceCalculator.Containers.TestsNiquIoC_Full
{
    public abstract class AutofacRegistration : IRegistration
    {
        public abstract void Register<TFrom, TTo>(object container)
            where TTo : TFrom;

        public object RegisterCallback(object container)
        {
            return container;
        }
    }
}