﻿using System;
using System.IO;
using System.Web;
using NiquIoC.Enums;
using NiquIoC.Test.WebApplication.Controllers;

namespace NiquIoC.Test.PerHttpContext
{
    public static class TestsHelper
    {
        public static T ResolveObject<T>(Container c, ResolveKind resolveKind)
        {
            var controller = new ResolveObjectController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var result = controller.Get<T>(c, resolveKind);

            return (T) result;
        }

        public static Tuple<T, T> ResolveObjects<T>(Container c, ResolveKind resolveKind)
        {
            var controller = new ResolveObjectController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var result1 = controller.Get<T>(c, resolveKind);
            var result2 = controller.Get<T>(c, resolveKind);

            return Tuple.Create((T) result1, (T) result2);
        }

        public static Tuple<T1, T2> ResolveObjects<T1, T2>(Container c, ResolveKind resolveKind)
        {
            var controller = new ResolveObjectController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var result1 = controller.Get<T1>(c, resolveKind);
            var result2 = controller.Get<T2>(c, resolveKind);

            return Tuple.Create((T1)result1, (T2)result2);
        }

        public static T BuildUpObject<T>(Container c, T obj, ResolveKind resolveKind)
        {
            var controller = new BuildUpObjectController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var result = controller.Get(c, obj, resolveKind);

            return (T) result;
        }

        public static Tuple<T, T> BuildUpObject<T>(Container c, T obj1, T obj2, ResolveKind resolveKind)
        {
            var controller = new BuildUpObjectController();
            HttpContext.Current = new HttpContext(new HttpRequest("", "http://tempuri.org", ""),
                new HttpResponse(new StringWriter()));

            var result1 = controller.Get(c, obj1, resolveKind);
            var result2 = controller.Get(c, obj2, resolveKind);

            return Tuple.Create((T) result1, (T) result2);
        }
    }
}