// -----------------------------------------------------------------------
// <copyright file="PlaygroundTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Web.Tests
{
    using System;
    using System.Reflection;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PlaygroundTest
    {
        [Fact]
        public void EqualInvariant()
        {
            Console.WriteLine("Łódź".Equals("łódź", StringComparison.InvariantCultureIgnoreCase));

            Assert.True("Łódź".Equals("łódź", StringComparison.InvariantCultureIgnoreCase));
            Assert.True("ŁóDź".Equals("łódź", StringComparison.InvariantCultureIgnoreCase));
            Assert.False("Łódź".Equals("lodz", StringComparison.InvariantCultureIgnoreCase));
            Assert.False("Łódź".Equals("Łodź", StringComparison.InvariantCultureIgnoreCase));
            Assert.False("Łódź".Equals("Łódż", StringComparison.InvariantCultureIgnoreCase));
            Assert.False("Łódź".Equals("lódz", StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void TestGetAssemlyInlining()
        {
            CalledType.CalledMethod();
        }

        [Fact]
        public void CircularDependecyMagic()
        {
            // 0 not 5
            Console.WriteLine(First.Beta);
            Assert.Equal(0, First.Beta);
        }

        [Fact]
        public void AutomaticBoxing()
        {
            new Alpha().BoxMe(2);
            new Alpha().BoxMe("ala");
        }

        [Fact]
        public void ComponentEvents()
        {
            //System.ComponentModel.Component component;
            foreach (var foo in typeof(Type).GetEvents())
            {
                Console.WriteLine(foo.Name);
            }
        }
    }

    class Alpha
    {
        public void BoxMe(Object o)
        {
            Console.WriteLine(o.ToString());
        }

        public void NotBoxMe<T>(T t)
        {
            Console.WriteLine(t.ToString());
        }
    }

    class CalledType
    {
        protected static void InternallyCalledMethod()
        {
            Console.WriteLine("Called Assembly in InternallyCalledMethod is {0}", Assembly.GetCallingAssembly().FullName);
        }

        public static void CalledMethod()
        {
            Console.WriteLine("Called Assembly in CalledMethod is {0}", Assembly.GetCallingAssembly().FullName);
            InternallyCalledMethod();
        }
    }

    class First
    {
        public static readonly int Alpha = 5;
        public static readonly int Beta = Second.Gamma;
    }

    class Second
    {
        public static readonly int Gamma = First.Alpha;
    }

}
