// -----------------------------------------------------------------------
// <copyright file="PlaygroundTest.cs" company="Agora SA">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Trader.TestsBase.Playground
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Xunit;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class PlaygroundTest
    {

        public enum Foo
        {
            alfa,
            Beta,
            [Display(Name = "GAMMA")]
            gamma
        }

        [Fact]
        public void TestEnumToStringReprezentation()
        {
            Assert.Equal(Foo.alfa.ToString(), "alfa");
            Assert.Equal(Foo.Beta.ToString(), "Beta");
            Assert.NotEqual(Foo.Beta.ToString(), "beta");
            Assert.NotEqual(Foo.gamma.ToString(), "GAMMA");
        }

        [Fact]
        public void StaticTest()
        {
            Console.WriteLine(First.Beta); 
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
