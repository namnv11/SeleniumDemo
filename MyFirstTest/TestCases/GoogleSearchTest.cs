using MyFirstTest.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstTest.TestCases
{
    public class GoogleSearchTest : BaseClass.BaseClass
    {
        [SetUp]
        public void Initial()
        {

        }

        [Test]
        public void GoogleSearch()
        {
            Page.GooglePages.InputSearch.SendKeys("Test");
        }
    }
}
