using System;
using System.Collections.Generic;
using System.Linq;
using Connect_Four;
using NUnit.Framework;

namespace Connect_Four____tests
{
    [TestFixture]
    public class MyTestConnectFour
    {
        [Test, Order(1)]
        public void FirstTest()
        {
            List<string> myList = new List<string>()
            {
            "A_Red",
            "B_Yellow",
            "A_Red",
            "B_Yellow",
            "A_Red",
            "B_Yellow",
            "G_Red",
            "B_Yellow"
            };

            Assert.That(ConnectFour.WhoIsWinner(myList), Is.EqualTo("Yellow").IgnoreCase, "it should return Yellow");
        }

        [Test, Order(2)]
        public void SecondTest()
        {
            List<string> myList = new List<string>()
            {
            "C_Yellow",
            "E_Red",
            "G_Yellow",
            "B_Red",
            "D_Yellow",
            "B_Red",
            "B_Yellow",
            "G_Red",
            "C_Yellow",
            "C_Red",
            "D_Yellow",
            "F_Red",
            "E_Yellow",
            "A_Red",
            "A_Yellow",
            "G_Red",
            "A_Yellow",
            "F_Red",
            "F_Yellow",
            "D_Red",
            "B_Yellow",
            "E_Red",
            "D_Yellow",
            "A_Red",
            "G_Yellow",
            "D_Red",
            "D_Yellow",
            "C_Red"
            };

            Assert.That(ConnectFour.WhoIsWinner(myList), Is.EqualTo("Yellow").IgnoreCase);
        }

        [Test, Order(3)]
        public void ThirdTest()
        {
            List<string> myList = new List<string>()
            {
            "A_Yellow",
            "B_Red",
            "B_Yellow",
            "C_Red",
            "G_Yellow",
            "C_Red",
            "C_Yellow",
            "D_Red",
            "G_Yellow",
            "D_Red",
            "G_Yellow",
            "D_Red",
            "F_Yellow",
            "E_Red",
            "D_Yellow"
            };

            Assert.That(ConnectFour.WhoIsWinner(myList), Is.EqualTo("Red").IgnoreCase, "it should return Red");
        }
    }

}